// <auto-generated> - Template:ModelsBackedByDto, Version:1.1, Id:f1539c0d-024f-4b1f-b346-132cdd9dd31f
using CodeGenHero.Logging;
using CodeGenHero.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeGenHero.ResourceScheduler.API.Client.Interface;
using CodeGenHero.ResourceScheduler.Model.RS.Interface;
using xDTO = CodeGenHero.ResourceScheduler.DTO.RS;

namespace CodeGenHero.ResourceScheduler.Model.RS
{

	public class LoadRequestResource : EventArgs
	{
		public LoadRequestResource(string propertyNameRequestingLoad)
		{
			PropertyNameRequestingLoad = propertyNameRequestingLoad;
		}

		public string PropertyNameRequestingLoad { get; set; }
	}


	public partial class Resource : BaseModel<IWebApiDataServiceRS>, IResource
	{
		public event EventHandler<LoadRequestResource> OnLazyLoadRequest = delegate { }; // Empty delegate. Thus we are sure that value is always != null because no one outside of the class can change it.
		private xDTO.Resource _dto = null;

		public Resource(ILoggingService log, IDataService<IWebApiDataServiceRS> dataService) : base(log, dataService)
		{
			_dto = new xDTO.Resource();
			OnLazyLoadRequest += HandleLazyLoadRequest;
		}

		public Resource(ILoggingService log, IDataService<IWebApiDataServiceRS> dataService, xDTO.Resource dto) : this(log, dataService)
		{
			_dto = dto;
		}


		public virtual string CreatedBy { get { return _dto.CreatedBy; } }
		public virtual System.DateTime CreatedDate { get { return _dto.CreatedDate; } }
		public virtual string Description { get { return _dto.Description; } }
		public virtual System.Guid Id { get { return _dto.Id; } }
		public virtual string ImageLink { get { return _dto.ImageLink; } }
		public virtual string ImageLinkThumb { get { return _dto.ImageLinkThumb; } }
		public virtual bool IsActive { get { return _dto.IsActive; } }
		public virtual bool IsDeleted { get { return _dto.IsDeleted; } }
		public virtual string Name { get { return _dto.Name; } }
		public virtual string UpdatedBy { get { return _dto.UpdatedBy; } }
		public virtual System.DateTime UpdatedDate { get { return _dto.UpdatedDate; } }

		private List<IResourceSchedule> _resourceSchedules = null; // Reverse Navigation


		public virtual List<IResourceSchedule> ResourceSchedules
		{
			get
			{
				if (_resourceSchedules == null && _dto != null)
				{	// The core DTO object is loaded, but this property is not loaded.
					if (_dto.ResourceSchedules != null)
					{	// The core DTO object has data for this property, load it into the model.
						_resourceSchedules = new List<IResourceSchedule>();
						foreach (var dtoItem in _dto.ResourceSchedules)
						{
							_resourceSchedules.Add(new ResourceSchedule(Log, DataService, dtoItem));
						}
					}
					else
					{	// Trigger the load data request - The core DTO object is loaded and does not have data for this property.
						OnLazyLoadRequest(this, new LoadRequestResource(nameof(ResourceSchedules)));
					}
				}

				return _resourceSchedules;
			}
		}



	}
}
