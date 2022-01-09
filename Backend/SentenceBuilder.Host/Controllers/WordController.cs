using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host.Controllers
{
	[ApiController]
	public class WordController : ControllerBase
	{
		private readonly IWordRepository _wordRepository;
		public WordController(IWordRepository wordRepository)
		{
			_wordRepository = wordRepository;
		}

		[HttpGet]
		[Route("api/v1/[controller]/Get/{wordTypeId:int}")]
		public async Task<ActionResult<IEnumerable<Word>>> GetAsync(int wordTypeId)
		{
			var words = await _wordRepository.GetAllWordsForWordType(wordTypeId);
			return !words.Any() ? StatusCode(404, "No words found for provided wordTypeId") 
				: new ActionResult<IEnumerable<Word>>(words);
		}
	}
}
