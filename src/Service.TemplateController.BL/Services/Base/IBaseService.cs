using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Pepegov.UnitOfWork.Entityes;
using Service.TemplateController.DAL.Application;

namespace Service.TemplateController.BL.Services.Base;

/// <summary>
/// Base methods for service
/// </summary>
/// <typeparam name="TEntity">Type for dbSet which implements</typeparam>
public interface IBaseService<TEntity> where TEntity : IEntity
{
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<TEntity?> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        CancellationToken cancellationToken = default);
    Task<IPagedList<TEntity>> GetPagedListAsync(int page, int pageSize = 20, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    
    Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    
    Task<TEntity?> Create(TEntity entity, CancellationToken cancellationToken = default);
    
    Task<bool?> Create(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task<bool> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<IList<TEntity>> GetByListIdsAsync(IEnumerable<Guid> ids, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    
    Task<IPagedList<TEntity>> GetPagedListByFilterAsync(BaseFilterModel filterModel, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    Task<IList<TEntity>> GetAllByFilterAsync(BaseFilterModel filterModel, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    
    Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int? count = null, CancellationToken cancellationToken = default);
}