using System.Collections.Generic;
using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;

namespace SentenceBuilder.Service.Interface
{
	public interface IWordTypeRepository
	{
		Task<IEnumerable<WordType>> GetAllWordTypes();
		Task<WordType> GetWordTypeAsync(int wordTypeId);
		Task<bool> WordTypeExist(int wordTypeId);
		Task<int> AddWordTypeAsync(WordType wordType);
		Task<int> UpdateWordTypeAsync(WordType wordType);
		Task<int> DeleteWordTypeAsync(int wordTypeId);
	}
}