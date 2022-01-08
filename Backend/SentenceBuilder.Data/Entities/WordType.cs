using System;

namespace SentenceBuilder.Data.Entities
{
	public class WordType
	{
		public int WordTypeId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime RecordDate { get; set; }
		public bool Active { get; set; }
	}
}
