using System;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using NUnit.Framework;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service.Tests
{
	public class TestSentenceRepository
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
		public async Task DoIt_WhenCalledWithSentence_ShouldSaveSentence()
		{
			//Arrange
			var sentence = new Sentence
			{
				Text = "The man is happy.",
				RecordDate = new DateTime(2022, 01, 08)
			};
			var sut = CreateSentenceRepository(ConnectionString);

			//Act
			var actual = await sut.AddSentence(sentence);

			//Assert
			actual.Should().Be(1);

		}

		private static ISentenceRepository CreateSentenceRepository(string connectionString)
		{
			ISentenceRepository sentenceRepository = new SentenceRepository(connectionString);
			return sentenceRepository;
		}
	}
}
