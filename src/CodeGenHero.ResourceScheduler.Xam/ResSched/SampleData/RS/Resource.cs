// <auto-generated> - Template:XamSample, Version:1.1, Id:9131a0a2-7ceb-4f4c-b8a9-6740ac19f66c
using System;
using CodeGenHero.ResourceScheduler.DTO.RS;

namespace CodeGenHero.ResourceScheduler.DTO.RS
{
	public static class DemoResource
	{
		public static System.Guid SampleResourceId00 = Guid.Parse("3600e0f6-6011-4d31-a723-47cb1423a075");
		public static System.Guid SampleResourceId01 = Guid.Parse("7d60f0ca-b6a9-4bba-9044-ba37ffb2329d");

		public static Resource SampleResource00
		{
			get
			{
				return new Resource()
				{
					Id = SampleResourceId00,
					CreatedBy = "SampleCreatedBy",
					CreatedDate = DateTime.Now,
					Description = "SampleDescription",
					ImageLink = "SampleImageLink",
					ImageLinkThumb = "SampleImageLinkThumb",
					IsActive = false,
					IsDeleted = false,
					UpdatedBy = "SampleUpdatedBy",
					UpdatedDate = DateTime.Now,
					Name = "SampleName",
				};
			}
		}
		public static Resource SampleResource01
		{
			get
			{
				return new Resource()
				{
					Id = SampleResourceId01,
					CreatedBy = "SampleCreatedBy",
					CreatedDate = DateTime.Now,
					Description = "SampleDescription",
					ImageLink = "SampleImageLink",
					ImageLinkThumb = "SampleImageLinkThumb",
					IsActive = false,
					IsDeleted = false,
					UpdatedBy = "SampleUpdatedBy",
					UpdatedDate = DateTime.Now,
					Name = "SampleName",
				};
			}
		}

	}
}