using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepo.Dapper.Wrapper; //For more info : https://github.com/Siphenathi/GenericRepo.Dapper.Wrapper
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service
{
	public class WordTypeRepository : IWordTypeRepository
	{
		private readonly IRepository<WordType> _wordTypeRepository;
		private const string TableName = "WordType";
		private const string PrimaryKeyName = "WordTypeId";

		public WordTypeRepository(string connectionString)
		{
			_wordTypeRepository = new Repository<WordType>(TableName, connectionString);
		}

		public async Task<IEnumerable<WordType>> GetAllWordTypes()
		{
			return await _wordTypeRepository.GetAllAsync();
		}

		public async Task<WordType> GetWordTypeAsync(int wordTypeId)
		{
			return await _wordTypeRepository.GetAsync(wordTypeId, PrimaryKeyName);
		}

		public async Task<bool> WordTypeExist(int wordTypeId)
		{
			var accounts = await _wordTypeRepository.GetAllAsync();
			var account = accounts.ToList().Find(wordType => wordType.WordTypeId == wordTypeId);
			return account != null;
		}

		public async Task<int> AddWordTypeAsync(WordType wordType)
		{
			return await _wordTypeRepository.InsertAsync(wordType, PrimaryKeyName);
		}

		public async Task<int> UpdateWordTypeAsync(WordType wordType)
		{
			var numberOfRowsAffected = await _wordTypeRepository.UpdateAsync(PrimaryKeyName, wordType, PrimaryKeyName);
			if (numberOfRowsAffected == 0) throw new KeyNotFoundException($"{TableName} with {PrimaryKeyName} [{wordType.WordTypeId}] could not be found.");
			return numberOfRowsAffected;
		}

		public async Task<int> DeleteWordTypeAsync(int wordTypeId)
		{
			var numberOfRowsAffected = await _wordTypeRepository.DeleteAsync(wordTypeId, PrimaryKeyName);
			if (numberOfRowsAffected == 0) throw new KeyNotFoundException($"{TableName} with {PrimaryKeyName} [{wordTypeId}] could not be found.");
			return numberOfRowsAffected;
		}
	}
}
