// <auto-generated> - Template:SqliteModelData, Version:1.1, Id:c5caad15-b3be-4443-87d8-7cabde59f7b0
using SQLite;

namespace CodeGenHero.ResourceScheduler.Xam.ModelData.RS
{
	[Table("User")]
	public partial class User
	{
		public string CreatedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public string Email { get; set; }

		[PrimaryKey]
		public System.Guid Id { get; set; }

		public string InstallationId { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public System.DateTime? LastLoginDate { get; set; }
		public string Name { get; set; }
		public string UpdatedBy { get; set; }
		public System.DateTime UpdatedDate { get; set; }
		public string UserName { get; set; }
	}
}
