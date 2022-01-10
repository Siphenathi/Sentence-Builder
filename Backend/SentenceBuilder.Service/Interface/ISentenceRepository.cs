using System.Collections.Generic;
using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;

namespace SentenceBuilder.Service.Interface
{
	public interface ISentenceRepository
	{
		Task<IEnumerable<Sentence>> GetAllSentences();
		Task<int> AddSentence(Sentence sentence);
	}
}