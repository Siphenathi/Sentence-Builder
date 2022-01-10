using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Model;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host.Controllers
{
	[ApiController]
	public class SentenceController : ControllerBase
	{
		private readonly ISentenceRepository _sentenceRepository;
		public SentenceController(ISentenceRepository sentenceRepository)
		{
			_sentenceRepository = sentenceRepository;
		}

		[HttpGet]
		[Route("api/v1/[controller]")]
		public async Task<ActionResult<IEnumerable<SentenceListModel>>> GetAsync()
		{
			var allSentences = await _sentenceRepository.GetAllSentences();
			var enumerable = allSentences as Sentence[] ?? allSentences.ToArray();
			return !enumerable.Any()
				? StatusCode(404, "No sentences found yet!")
				: new ActionResult<IEnumerable<SentenceListModel>>(MapSentenceObject(enumerable));
		}

		[HttpPost]
		[Route("api/v1/[controller]/Add")]
		public async Task<IActionResult> Add(SentenceViewModel sentenceViewModel)
		{
			try
			{
				var sentence = new Sentence
				{
					Text = sentenceViewModel.Text.Trim(),
					RecordDate = DateTime.Now
				};
				var numberOfRowsAffected = await _sentenceRepository.AddSentence(sentence);
				return Ok(numberOfRowsAffected);
			}
			catch (Exception exception)
			{
				return StatusCode(500, exception.Message);
			}
		}

		private static IEnumerable<SentenceListModel> MapSentenceObject(IEnumerable<Sentence> sentences)
		{
			var sentenceListModels = new List<SentenceListModel>();
			sentences.ToList().ForEach(sentence =>
			{
				sentenceListModels.Add(new SentenceListModel
				{
					Text = sentence.Text,
					RecordDate = sentence.RecordDate
				});
			});
			return sentenceListModels;
		}
	}
}
