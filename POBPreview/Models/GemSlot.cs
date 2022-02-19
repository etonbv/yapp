using System;
namespace POBPreview.Models
{
	public class GemSlot
	{
		public string Name { get; set; }
		public List<GemGroup> GemGroups { get; set; } = new List<GemGroup>();
	}
}

