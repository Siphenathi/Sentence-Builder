using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Host.Controllers;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host.Tests
{
	[TestFixture]
	public class TestWordController
	{
		[Test]
		public async Task GetAllWordsForWordType_WhenCalled_ShouldGetAllWords()
		{
			//Arrange
			const int wordTypeId = 1;
			var wordRepository = Substitute.For<IWordRepository>();
			wordRepository.GetAllWordsForWordType(wordTypeId).Returns(new List<Word> {
				new Word
				{
					WordTypeId = 1,
					Name ="The",
					RecordDate = new DateTime(2022, 01, 08),
					Active = true
				},
				new Word
				{
					WordTypeId = 101,
					Name ="Man",
					RecordDate = new DateTime(2022, 01, 08),
					Active = true
				}
			});

			var wordController = new WordController(wordRepository);

			//Act
			_ = await wordController.GetAsync(wordTypeId);

			//Assert
			await wordRepository.Received(1).GetAllWordsForWordType(1);
		}
	}
}
