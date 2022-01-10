using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Host.Controllers;
using SentenceBuilder.Model;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host.Tests
{
	[TestFixture]
	public class TestSentenceController
	{
		[Test]
		public async Task GetAllWordTypes_WhenCalled_ShouldGetAllWordTypes()
		{
			//Arrange
			var sentenceRepository = Substitute.For<ISentenceRepository>();
			sentenceRepository.GetAllSentences().Returns(new List<Sentence> {
				new Sentence
				{
					Text = "The man is happy.",
					RecordDate = new DateTime(2022, 01, 08)
				},
				new Sentence
				{
					Text = "blaah blaah blaah",
					RecordDate = new DateTime(2022, 01, 08)
				}
			});

			var sentenceController = new SentenceController(sentenceRepository);

			//Act
			_ = await sentenceController.GetAsync();

			//Assert
			await sentenceRepository.Received(1).GetAllSentences();
		}

		[Test]
		public async Task AddSentence_WhenCalled_ShouldAddSentence()
		{
			//Arrange
			var sentenceViewModel = new SentenceViewModel
			{
				Text = "This car is red"
			};
			var sentenceRepository = Substitute.For<ISentenceRepository>();
			sentenceRepository.AddSentence(Arg.Any<Sentence>()).Returns(1);

			var wordController = new SentenceController(sentenceRepository);

			//Act
			_ = await wordController.Add(sentenceViewModel);

			//Assert
			await sentenceRepository.Received(1).AddSentence(Arg.Is<Sentence>(sentence => sentence.Text== "This car is red"));
		}
	}
}
