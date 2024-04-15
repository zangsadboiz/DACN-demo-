using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fshop.Models
{
	[Table("FounderProfile")]
	public class Founder
	{
		[Key]
		public long FounderID { get; set; }
		public string? FounderName { get; set; }
		public string? FounderNickName { get; set; }
		public string? Images { get; set; }
		public bool? IsActive { get; set; }
		public int Category { get; set; }
		public int Status { get; set; }
		public int MenuID { get; set; }


	}
}
