using System;
using System.ComponentModel.DataAnnotations;

namespace POBPreview.Models
{
	public class POBCode
	{
		[Required]
		[POBCodeValidator]
		public string Code { get; set; }
	}
}

