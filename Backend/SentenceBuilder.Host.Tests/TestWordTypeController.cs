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
	public class TestWordTypeController
	{
		[Test]
		public async Task GetAllWordTypes_WhenCalled_ShouldGetAllWordTypes()
		{
			//Arrange
			var wordTypeRepository = Substitute.For<IWordTypeRepository>();
			wordTypeRepository.GetAllWordTypes().Returns(new List<WordType> {
				new WordType
				{
					WordTypeId = 1,
					Name ="Noun",
					Description = "Description",
					RecordDate = new DateTime(2022, 01, 08),
					Active = true
				},
				new WordType
				{
					WordTypeId = 101,
					Name ="Adverb",
					Description = "Description",
					RecordDate = new DateTime(2022, 01, 08),
					Active = true
				}
			});

			var wordTypeController = new WordTypeController(wordTypeRepository);

			//Act
			_ = await wordTypeController.GetAsync();

			//Assert
			await wordTypeRepository.Received(1).GetAllWordTypes();
		}
	}
}