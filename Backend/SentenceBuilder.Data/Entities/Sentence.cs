using System;

namespace SentenceBuilder.Data.Entities
{
	public class Sentence
	{
		public int SentenceId { get; set; }
		public string Text { get; set; }
		public DateTime RecordDate { get; set; }
	}
}