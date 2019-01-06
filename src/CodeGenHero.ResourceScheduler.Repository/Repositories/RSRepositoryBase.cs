// <auto-generated> - Template:RepositoryBase, Version:1.1, Id:70230bd4-f88f-41d8-a9c6-6e40aded5c07
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CodeGenHero.ResourceScheduler.Repository.Entities.RS;
using CodeGenHero.ResourceScheduler.Repository.Interface;
using CodeGenHero.Repository;
using cghEnums = CodeGenHero.Repository.Enums;

namespace CodeGenHero.ResourceScheduler.Repository
{
	public abstract partial class RSRepositoryBase : IRSRepositoryCrud
	{
		private RSDataContext _ctx;

		public RSRepositoryBase(RSDataContext ctx)
		{
			_ctx = ctx;

			// Disable lazy loading - if not, related properties are auto-loaded when
			// they are accessed for the first time, which means they'll be included when
			// we serialize (b/c the serialization process accesses those properties).

			// We don't want that, so we turn it off.  We want to eagerly load them (using Include) manually.

			ctx.Configuration.LazyLoadingEnabled = false;

			if (System.Diagnostics.Debugger.IsAttached)
			{   // Write EF queries to the output console.
				ctx.Database.Log = x => System.Diagnostics.Debug.WriteLine(x);
			}
		}

		#region Generic Operations

		private async Task<IRepositoryActionResult<TEntity>> DeleteAsync<TEntity>(TEntity item) where TEntity : class
		{
			try
			{
				if (item == null)
				{
					return new RepositoryActionResult<TEntity>(null, cghEnums.RepositoryActionStatus.NotFound);
				}

				DbSet<TEntity> itemSet = _ctx.Set<TEntity>();
				itemSet.Remove(item);
				await _ctx.SaveChangesAsync();
				return new RepositoryActionResult<TEntity>(null, cghEnums.RepositoryActionStatus.Deleted);
			}
			catch(Exception ex)
			{
				return new RepositoryActionResult<TEntity>(null, cghEnums.RepositoryActionStatus.Error, ex);
			}
		}

		public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
		{
			return _ctx.Set<TEntity>();
		}

		public async Task<IRepositoryActionResult<TEntity>> InsertAsync<TEntity>(TEntity item) where TEntity : class
		{
			try
			{
				DbSet<TEntity> itemSet = _ctx.Set<TEntity>();
				itemSet.Add(item);
				var result = await _ctx.SaveChangesAsync();
				RunCustomLogicAfterEveryInsert<TEntity>(item, result);

				if (result > 0)
				{
					return new RepositoryActionResult<TEntity>(item, cghEnums.RepositoryActionStatus.Created);
				}
				else
				{
					return new RepositoryActionResult<TEntity>(item, cghEnums.RepositoryActionStatus.NothingModified, null);
				}
			}
			catch(Exception ex)
			{
				return new RepositoryActionResult<TEntity>(null, cghEnums.RepositoryActionStatus.Error, ex);
			}
		}

		private async Task<IRepositoryActionResult<TEntity>> UpdateAsync<TEntity>(TEntity item, TEntity existingItem) where TEntity : class
		{
			try
			{ // only update when a record already exists for this id
				if (existingItem == null)
				{
					return new RepositoryActionResult<TEntity>(item, cghEnums.RepositoryActionStatus.NotFound);
				}

				// change the original entity status to detached; otherwise, we get an error on attach as the entity is already in the dbSet
				// set original entity state to detached
				_ctx.Entry(existingItem).State = EntityState.Detached;
				DbSet<TEntity> itemSet = _ctx.Set<TEntity>();
				itemSet.Attach(item); // attach & save
				_ctx.Entry(item).State = EntityState.Modified; // set the updated entity state to modified, so it gets updated.

				var result = await _ctx.SaveChangesAsync();
				RunCustomLogicAfterEveryUpdate<TEntity>(newItem: item, oldItem: existingItem, numObjectsWritten: result);

				if (result > 0)
				{
					return new RepositoryActionResult<TEntity>(item, cghEnums.RepositoryActionStatus.Updated);
				}
				else
				{
					return new RepositoryActionResult<TEntity>(item, cghEnums.RepositoryActionStatus.NothingModified, null);
				}
			}
			catch (Exception ex)
			{
				return new RepositoryActionResult<TEntity>(null, cghEnums.RepositoryActionStatus.Error, ex);
			}
		}

		partial void RunCustomLogicAfterEveryInsert<T>(T item, int numObjectsWritten) where T : class;

		partial void RunCustomLogicAfterEveryUpdate<T>(T newItem, T oldItem, int numObjectsWritten) where T : class;

		#endregion Generic Operations

		#region Resource

		public async Task<IRepositoryActionResult<Resource>> InsertAsync(Resource item)
		{
			var result = await InsertAsync<Resource>(item);
			RunCustomLogicAfterInsert_Resource(item, result);

			return result;
		}


		public IQueryable<Resource> GetQueryable_Resource()
		{
			return _ctx.Set<Resource>();
		}

			public async Task<Resource> Get_ResourceAsync(System.Guid id, int numChildLevels)
			{
				var qryItem = GetQueryable_Resource().AsNoTracking();
				RunCustomLogicOnGetQueryableByPK_Resource(ref qryItem, id, numChildLevels);

				var dbItem = await qryItem.Where(x => x.Id == id).FirstOrDefaultAsync();
				if (!(dbItem is null))
				{
					RunCustomLogicOnGetEntityByPK_Resource(ref dbItem, id, numChildLevels);
				}

				return dbItem;
			}

			public async Task<Resource> GetFirstOrDefaultAsync(Resource item)
			{
				return await _ctx.Resources.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
			}


		public async Task<IRepositoryActionResult<Resource>> UpdateAsync(Resource item)
		{
			var oldItem = await _ctx.Resources.FirstOrDefaultAsync(x => x.Id == item.Id);
			var result = await UpdateAsync<Resource>(item, oldItem);
			RunCustomLogicAfterUpdate_Resource(newItem: item, oldItem: oldItem, result: result);

			return result;
		}

			public async Task<IRepositoryActionResult<Resource>> Delete_ResourceAsync(System.Guid id)
			{
				return await DeleteAsync<Resource>(_ctx.Resources.Where(x => x.Id == id).FirstOrDefault());
			}
			public async Task<IRepositoryActionResult<Resource>> DeleteAsync(Resource item)
			{
				return await DeleteAsync<Resource>(_ctx.Resources.Where(x => x.Id == item.Id).FirstOrDefault());
			}

		partial void RunCustomLogicAfterInsert_Resource(Resource item, IRepositoryActionResult<Resource> result);

		partial void RunCustomLogicAfterUpdate_Resource(Resource newItem, Resource oldItem, IRepositoryActionResult<Resource> result);

		partial void RunCustomLogicOnGetQueryableByPK_Resource(ref IQueryable<Resource> qryItem, System.Guid id, int numChildLevels);

		partial void RunCustomLogicOnGetEntityByPK_Resource(ref Resource dbItem, System.Guid id, int numChildLevels);



		#endregion Resource

		#region ResourceSchedule

		public async Task<IRepositoryActionResult<ResourceSchedule>> InsertAsync(ResourceSchedule item)
		{
			var result = await InsertAsync<ResourceSchedule>(item);
			RunCustomLogicAfterInsert_ResourceSchedule(item, result);

			return result;
		}


		public IQueryable<ResourceSchedule> GetQueryable_ResourceSchedule()
		{
			return _ctx.Set<ResourceSchedule>();
		}

			public async Task<ResourceSchedule> Get_ResourceScheduleAsync(System.Guid id, int numChildLevels)
			{
				var qryItem = GetQueryable_ResourceSchedule().AsNoTracking();
				RunCustomLogicOnGetQueryableByPK_ResourceSchedule(ref qryItem, id, numChildLevels);

				var dbItem = await qryItem.Where(x => x.Id == id).FirstOrDefaultAsync();
				if (!(dbItem is null))
				{
					RunCustomLogicOnGetEntityByPK_ResourceSchedule(ref dbItem, id, numChildLevels);
				}

				return dbItem;
			}

			public async Task<ResourceSchedule> GetFirstOrDefaultAsync(ResourceSchedule item)
			{
				return await _ctx.ResourceSchedules.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
			}


		public async Task<IRepositoryActionResult<ResourceSchedule>> UpdateAsync(ResourceSchedule item)
		{
			var oldItem = await _ctx.ResourceSchedules.FirstOrDefaultAsync(x => x.Id == item.Id);
			var result = await UpdateAsync<ResourceSchedule>(item, oldItem);
			RunCustomLogicAfterUpdate_ResourceSchedule(newItem: item, oldItem: oldItem, result: result);

			return result;
		}

			public async Task<IRepositoryActionResult<ResourceSchedule>> Delete_ResourceScheduleAsync(System.Guid id)
			{
				return await DeleteAsync<ResourceSchedule>(_ctx.ResourceSchedules.Where(x => x.Id == id).FirstOrDefault());
			}
			public async Task<IRepositoryActionResult<ResourceSchedule>> DeleteAsync(ResourceSchedule item)
			{
				return await DeleteAsync<ResourceSchedule>(_ctx.ResourceSchedules.Where(x => x.Id == item.Id).FirstOrDefault());
			}

		partial void RunCustomLogicAfterInsert_ResourceSchedule(ResourceSchedule item, IRepositoryActionResult<ResourceSchedule> result);

		partial void RunCustomLogicAfterUpdate_ResourceSchedule(ResourceSchedule newItem, ResourceSchedule oldItem, IRepositoryActionResult<ResourceSchedule> result);

		partial void RunCustomLogicOnGetQueryableByPK_ResourceSchedule(ref IQueryable<ResourceSchedule> qryItem, System.Guid id, int numChildLevels);

		partial void RunCustomLogicOnGetEntityByPK_ResourceSchedule(ref ResourceSchedule dbItem, System.Guid id, int numChildLevels);



		#endregion ResourceSchedule

		#region User

		public async Task<IRepositoryActionResult<User>> InsertAsync(User item)
		{
			var result = await InsertAsync<User>(item);
			RunCustomLogicAfterInsert_User(item, result);

			return result;
		}


		public IQueryable<User> GetQueryable_User()
		{
			return _ctx.Set<User>();
		}

			public async Task<User> Get_UserAsync(System.Guid id, int numChildLevels)
			{
				var qryItem = GetQueryable_User().AsNoTracking();
				RunCustomLogicOnGetQueryableByPK_User(ref qryItem, id, numChildLevels);

				var dbItem = await qryItem.Where(x => x.Id == id).FirstOrDefaultAsync();
				if (!(dbItem is null))
				{
					RunCustomLogicOnGetEntityByPK_User(ref dbItem, id, numChildLevels);
				}

				return dbItem;
			}

			public async Task<User> GetFirstOrDefaultAsync(User item)
			{
				return await _ctx.Users.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
			}


		public async Task<IRepositoryActionResult<User>> UpdateAsync(User item)
		{
			var oldItem = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == item.Id);
			var result = await UpdateAsync<User>(item, oldItem);
			RunCustomLogicAfterUpdate_User(newItem: item, oldItem: oldItem, result: result);

			return result;
		}

			public async Task<IRepositoryActionResult<User>> Delete_UserAsync(System.Guid id)
			{
				return await DeleteAsync<User>(_ctx.Users.Where(x => x.Id == id).FirstOrDefault());
			}
			public async Task<IRepositoryActionResult<User>> DeleteAsync(User item)
			{
				return await DeleteAsync<User>(_ctx.Users.Where(x => x.Id == item.Id).FirstOrDefault());
			}

		partial void RunCustomLogicAfterInsert_User(User item, IRepositoryActionResult<User> result);

		partial void RunCustomLogicAfterUpdate_User(User newItem, User oldItem, IRepositoryActionResult<User> result);

		partial void RunCustomLogicOnGetQueryableByPK_User(ref IQueryable<User> qryItem, System.Guid id, int numChildLevels);

		partial void RunCustomLogicOnGetEntityByPK_User(ref User dbItem, System.Guid id, int numChildLevels);



		#endregion User

	}
}