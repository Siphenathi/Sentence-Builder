using System.Collections.Generic;
using System.Threading.Tasks;
using GenericRepo.Dapper.Wrapper; //For more info : https://github.com/Siphenathi/GenericRepo.Dapper.Wrapper
using SentenceBuilder.Data.Entities;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Service
{
	public class SentenceRepository : ISentenceRepository
	{
		private readonly IRepository<Sentence> _sentenceRepository;
		private const string TableName = "Sentence";
		private const string PrimaryKeyName = "SentenceId";

		public SentenceRepository(string connectionString)
		{
			_sentenceRepository = new Repository<Sentence>(TableName, connectionString);
		}

		public async Task<IEnumerable<Sentence>> GetAllSentences()
		{
			return await _sentenceRepository.GetAllAsync();
		}

		public async Task<int> AddSentence(Sentence sentence)
		{
			return await _sentenceRepository.InsertAsync(sentence, PrimaryKeyName);
		}
	}
}
