using System.Collections.Generic;
using System.Threading.Tasks;
using SentenceBuilder.Data.Entities;

namespace SentenceBuilder.Service.Interface
{
	public interface IWordTypeRepository
	{
		Task<IEnumerable<WordType>> GetAllWordTypes();
	}
}