// <auto-generated> - Template:ModelsBackedByDtoInterface, Version:1.1, Id:4d03f2c7-de27-4aae-a267-cad747c9606a
using System;
using System.Collections.Generic;

namespace CodeGenHero.ResourceScheduler.Model.RS.Interface
{
	public partial interface IResourceSchedule
	{
		string CreatedBy { get; }
		System.DateTime CreatedDate { get; }
		System.Guid Id { get; }
		bool IsDeleted { get; }
		System.DateTime ReservationEndDateTime { get; }
		string ReservationNotes { get; }
		System.DateTime ReservationStartDateTime { get; }
		System.Guid? ReservedByUserId { get; }
		string ReservedForUser { get; }
		System.DateTime ReservedOnDateTime { get; }
		System.Guid ResourceId { get; }
		string UpdatedBy { get; }
		System.DateTime UpdatedDate { get; }

		IResource Resource { get; }
		IUser User { get; }


	}
}