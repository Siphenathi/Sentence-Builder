using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;

namespace SentenceBuilder.Service.Interface
{
	public interface ISentenceRepository
	{
		Task<int> AddSentence(Sentence sentence);
	}
}