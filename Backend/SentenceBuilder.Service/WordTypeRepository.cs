using System.Collections.Generic;
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
	}
}
