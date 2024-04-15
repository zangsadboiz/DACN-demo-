using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fshop.Models
{
	[Table("IntroductionFeatures")]
	public class About
	{
		[Key]
		public int FeaturesID { get; set; }
		public string? FeaturesTitle { get; set; }
		public string? FeaturesIcon { get; set; }
		public string? Description { get; set; }
		public bool? IsActive { get; set; }
		public int Category { get; set; }
		public int Status { get; set; }
		public int MenuID { get; set; }


	}
}
