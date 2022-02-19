using System;
namespace POBPreview.Models
{
	public class GemGroup
	{
		public Gem MainGem { get; set; }

		public List<Gem> SupportGems { get; set; } = new List<Gem>();
	}
}

