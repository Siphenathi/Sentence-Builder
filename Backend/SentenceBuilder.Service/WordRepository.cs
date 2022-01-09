using System.Collections.Generic;
using System.Threading.Tasks;
using GenericRepo.Dapper.Wrapper; //For more info : https://github.com/Siphenathi/GenericRepo.Dapper.Wrapper
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service
{
	public class WordRepository : IWordRepository
	{
		private readonly IRepository<Word> _wordRepository;
		private const string TableName = "Word";

		public WordRepository(string connectionString)
		{
			_wordRepository = new Repository<Word>(TableName, connectionString);
		}

		public async Task<IEnumerable<Word>> GetAllWordsForWordType(int wordTypeId)
		{
			return await _wordRepository.GetAllAsync(wordTypeId, "WordTypeId");
		}
	}
}
