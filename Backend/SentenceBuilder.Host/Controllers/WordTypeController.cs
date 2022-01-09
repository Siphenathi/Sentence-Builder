using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host.Controllers
{
	[ApiController]
	public class WordTypeController : ControllerBase
	{
		private readonly IWordTypeRepository _wordTypeRepository;
		public WordTypeController(IWordTypeRepository wordTypeRepository)
		{
			_wordTypeRepository = wordTypeRepository;
		}

		[HttpGet]
		[Route("api/v1/[controller]")]
		public async Task<ActionResult<IEnumerable<WordType>>> GetAsync()
		{
			var allWordTypes = await _wordTypeRepository.GetAllWordTypes();
			return !allWordTypes.Any() ? StatusCode(404, "No words found yet!") : new ActionResult<IEnumerable<WordType>>(allWordTypes);
		}
	}
}
