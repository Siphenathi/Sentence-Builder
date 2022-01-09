using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using NUnit.Framework;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service.Tests
{
	public class TestWordRepository
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
		public async Task GetAllWordForWordTypes_WhenCalled_ShouldReturnTheWords()
		{
			//Arrange
			const int wordTypeId = 1;
			var sut = CreateWordRepository(ConnectionString);

			//Act
			var actual = await sut.GetAllWordsForWordType(wordTypeId);

			//Assert
			actual.Count().Should().BeGreaterOrEqualTo(0);
		}

		private static IWordRepository CreateWordRepository(string connectionString)
		{
			IWordRepository wordRepository = new WordRepository(connectionString);
			return wordRepository;
		}
	}
}
