using System;
using System.ComponentModel.DataAnnotations;

namespace SentenceBuilder.Model
{
	public class SentenceViewModel
	{
		[Required]
		public string Text { get; set; }
	}
}
