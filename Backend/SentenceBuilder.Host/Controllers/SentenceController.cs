using System;
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

		[HttpPost]
		[Route("api/v1/[controller]/Add")]
		public async Task<IActionResult> Add(SentenceViewModel sentenceViewModel)
		{
			try
			{
				var sentence = new Sentence
				{
					Text = sentenceViewModel.Text,
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
	}
}
