using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using NUnit.Framework;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service.Tests
{
	public class Tests
	{
		private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=SentenceBuilderContext";
		private TransactionScope _scope;

		[SetUp]
		public void Setup()
		{
			_scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
		}

		[TearDown]
		public void TearDown()
		{
			_scope.Dispose();
		}

		[Test]
		public async Task GetAllWordTypes_WhenCalled_ShouldReturnAllWordTypes()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);

			//Act
			var actual = await sut.GetAllWordTypes();

			//Assert
			actual.Count().Should().BeGreaterOrEqualTo(0);
		}

		[Test]
		public async Task GetWordType_WhenCalled_ShouldReturnWordType()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);

			//Act
			var actual = await sut.GetWordTypeAsync(1);

			//Assert
			actual.Should().NotBeNull();
		}

		[Test]
		public void GetWordType_WhenCalledWithNonExistenceWordTypeId_ShouldThrowException()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);

			//Act
			var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => sut.GetWordTypeAsync(1264949526));

			//Assert
			exception.Message.Should().Contain("WordTypeId [1264949526] could not be found.");
		}

		[Test]
		public async Task AddWordType_WhenCalledWithWordType_ShouldSaveWordType()
		{
			const int expectedNumberOfRowsToBeAffected = 1;
			var sut = CreateWordTypeRepository(ConnectionString);
			var wordType = new WordType
			{
				Name = "Name",
				Description = "blaah blaah",
				RecordDate = new DateTime(2022, 01, 07),
				Active = true
			};

			//Act
			var actual = await sut.AddWordTypeAsync(wordType);

			//Assert
			actual.Should().Be(expectedNumberOfRowsToBeAffected);
		}

		[Test]
		public async Task UpdateWordType_WhenCalledWithExistingWordType_ShouldUpdateWordType()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);
			var wordType = new WordType
			{
				WordTypeId = 101,
				Name = "Name",
				Description = "blaah blaah",
				RecordDate = new DateTime(2022, 01, 07),
				Active = true
			};

			//act
			var actual = await sut.UpdateWordTypeAsync(wordType);

			//Assert
			actual.Should().Be(1);
		}

		[Test]
		public void UpdateWordType_WhenCalledWithNonExistentWordType_ShouldThrowArException()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);
			var wordType = new WordType
			{
				WordTypeId = 999991,
				Name = "Name",
				Description = "blaah blaah",
				RecordDate = new DateTime(2022, 01, 07),
				Active = true
			};

			//act
			var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => sut.UpdateWordTypeAsync(wordType));

			//Assert
			Assert.AreEqual("WordType with WordTypeId [999991] could not be found.", exception.Message);
		}

		[Test]
		public void DeleteWordType_WhenCalledWithNonExistentCode_ShouldThrowException()
		{
			//Arrange 
			var sut = CreateWordTypeRepository(ConnectionString);
			const int wordTypeId = 9999;

			//Act
			var actual = Assert.ThrowsAsync<KeyNotFoundException>(() => sut.DeleteWordTypeAsync(wordTypeId));

			//Assert
			actual.Message.Should().Be("WordType with WordTypeId [9999] could not be found.");
		}

		[Test]
		public async Task DeleteWordType_WhenCalledWithCode_ShouldDeleteWordType()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);
			const int numberOfRowsAffected = 1;
			const int wordTypeId = 201;

			//Act
			var actual = await sut.DeleteWordTypeAsync(wordTypeId);

			//Assert
			actual.Should().Be(numberOfRowsAffected);
		}

		[Test]
		public async Task WordTypeExist_WhenCalledWithExistentParentCode_ShouldTrueWordTypeExist()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);
			const int wordTypeId = 1;

			//Act
			var actual = await sut.WordTypeExist(wordTypeId);

			//Assert
			actual.Should().Be(true);
		}

		[Test]
		public async Task WordTypeExist_WhenCalledWithNonExistentParentCode_ShouldFalseWordTypeDoesNotExist()
		{
			//Arrange
			var sut = CreateWordTypeRepository(ConnectionString);
			const int wordTypeId = 99999;

			//Act
			var actual = await sut.WordTypeExist(wordTypeId);

			//Assert
			actual.Should().Be(false);
		}

		private static IWordTypeRepository CreateWordTypeRepository(string connectionString)
		{
			IWordTypeRepository wordTypeRepository = new WordTypeRepository(connectionString);
			return wordTypeRepository;
		}
	}
}