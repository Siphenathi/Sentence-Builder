using System;

namespace SentenceBuilder.Data.Entities
{
	public class Word
	{
		public int WordId { get; set; }
		public int WordTypeId { get; set; }
		public string Name { get; set; }
		public DateTime RecordDate { get; set; }
		public bool Active { get; set; }
	}
}