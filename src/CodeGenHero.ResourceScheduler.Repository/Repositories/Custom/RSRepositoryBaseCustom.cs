// <auto-generated> - Template:RepositoryBasePartialMethods, Version:1.1, Id:ee9fed0b-0773-4b23-a17f-a9fb2004f9be
using System;
using System.Data.Entity;
using System.Linq;
using entRS = CodeGenHero.ResourceScheduler.Repository.Entities.RS;
using CodeGenHero.ResourceScheduler.Repository.Interface;
using CodeGenHero.Repository;

namespace CodeGenHero.ResourceScheduler.Repository
{
	public abstract partial class RSRepositoryBase : IRSRepositoryCrud
	{

		/// <summary>
		/// Custom logic that is generally used to include related entities to return with the parent entity that was requested.
		/// </summary>
		/// <param name="qryItem"></param>
		/// <param name="id"></param>
		/// <param name="numChildLevels"></param>
		 partial void RunCustomLogicOnGetQueryableByPK_Resource(ref IQueryable<entRS.Resource> qryItem, System.Guid id, int numChildLevels)
		 {
			 if (numChildLevels > 0)
			 {
				 qryItem = qryItem
				 .Include(x => x.ResourceSchedules).AsNoTracking();
			 }
		 }


		///// <summary>
		///// A sample implementation of custom logic used to either manipulate a DTO item or include related entities.
		///// </summary>
		///// <param name="dbItem"></param>
		///// <param name="id"></param>
		///// <param name="numChildLevels"></param>
		// partial void RunCustomLogicOnGetEntityByPK_Resource(ref entRS.Resource dbItem, System.Guid id, int numChildLevels)
		// {
			// if (numChildLevels > 1)
			// {
				// int[] orderLineItemIds = dbItem.OrderLineItems.Select(x => x.OrderLineItemId).ToArray();

				// var lineItemDiscounts = Repo.RSDataContext.OrderLineItemDiscounts.Where(x => orderLineItemIds.Contains(x.OrderLineItemId)).ToList();

				// foreach (var lineItemDiscount in lineItemDiscounts)
				// { // Find the match and add the item to it.
					// var orderLineItem = dbItem.OrderLineItems.Where(x => x.OrderLineItemId == lineItemDiscount.OrderLineItemId).FirstOrDefault();

					// if (orderLineItem == null)
					// {
						// throw new System.Data.Entity.Core.ObjectNotFoundException($"Unable to locate matching OrderLineItem record for {lineItemDiscount.OrderLineItemId}."
					// }

					// orderLineItem.LineItemDiscounts.Add(lineItemDiscount);
				// }
			// }

		// }

		/// <summary>
		/// Custom logic that is generally used to include related entities to return with the parent entity that was requested.
		/// </summary>
		/// <param name="qryItem"></param>
		/// <param name="id"></param>
		/// <param name="numChildLevels"></param>
		 partial void RunCustomLogicOnGetQueryableByPK_ResourceSchedule(ref IQueryable<entRS.ResourceSchedule> qryItem, System.Guid id, int numChildLevels)
		 {
			 if (numChildLevels > 0)
			 {
				 qryItem = qryItem
				 .Include(x => x.Resource).AsNoTracking()
				 .Include(x => x.User).AsNoTracking();
			 }
		 }


		///// <summary>
		///// A sample implementation of custom logic used to either manipulate a DTO item or include related entities.
		///// </summary>
		///// <param name="dbItem"></param>
		///// <param name="id"></param>
		///// <param name="numChildLevels"></param>
		// partial void RunCustomLogicOnGetEntityByPK_ResourceSchedule(ref entRS.ResourceSchedule dbItem, System.Guid id, int numChildLevels)
		// {
			// if (numChildLevels > 1)
			// {
				// int[] orderLineItemIds = dbItem.OrderLineItems.Select(x => x.OrderLineItemId).ToArray();

				// var lineItemDiscounts = Repo.RSDataContext.OrderLineItemDiscounts.Where(x => orderLineItemIds.Contains(x.OrderLineItemId)).ToList();

				// foreach (var lineItemDiscount in lineItemDiscounts)
				// { // Find the match and add the item to it.
					// var orderLineItem = dbItem.OrderLineItems.Where(x => x.OrderLineItemId == lineItemDiscount.OrderLineItemId).FirstOrDefault();

					// if (orderLineItem == null)
					// {
						// throw new System.Data.Entity.Core.ObjectNotFoundException($"Unable to locate matching OrderLineItem record for {lineItemDiscount.OrderLineItemId}."
					// }

					// orderLineItem.LineItemDiscounts.Add(lineItemDiscount);
				// }
			// }

		// }

		/// <summary>
		/// Custom logic that is generally used to include related entities to return with the parent entity that was requested.
		/// </summary>
		/// <param name="qryItem"></param>
		/// <param name="id"></param>
		/// <param name="numChildLevels"></param>
		 partial void RunCustomLogicOnGetQueryableByPK_User(ref IQueryable<entRS.User> qryItem, System.Guid id, int numChildLevels)
		 {
			 if (numChildLevels > 0)
			 {
				 qryItem = qryItem
				 .Include(x => x.ResourceSchedules).AsNoTracking();
			 }
		 }


		///// <summary>
		///// A sample implementation of custom logic used to either manipulate a DTO item or include related entities.
		///// </summary>
		///// <param name="dbItem"></param>
		///// <param name="id"></param>
		///// <param name="numChildLevels"></param>
		// partial void RunCustomLogicOnGetEntityByPK_User(ref entRS.User dbItem, System.Guid id, int numChildLevels)
		// {
			// if (numChildLevels > 1)
			// {
				// int[] orderLineItemIds = dbItem.OrderLineItems.Select(x => x.OrderLineItemId).ToArray();

				// var lineItemDiscounts = Repo.RSDataContext.OrderLineItemDiscounts.Where(x => orderLineItemIds.Contains(x.OrderLineItemId)).ToList();

				// foreach (var lineItemDiscount in lineItemDiscounts)
				// { // Find the match and add the item to it.
					// var orderLineItem = dbItem.OrderLineItems.Where(x => x.OrderLineItemId == lineItemDiscount.OrderLineItemId).FirstOrDefault();

					// if (orderLineItem == null)
					// {
						// throw new System.Data.Entity.Core.ObjectNotFoundException($"Unable to locate matching OrderLineItem record for {lineItemDiscount.OrderLineItemId}."
					// }

					// orderLineItem.LineItemDiscounts.Add(lineItemDiscount);
				// }
			// }

		// }
	}
}

