using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Pepegov.UnitOfWork;
using Pepegov.UnitOfWork.Entityes;
using Pepegov.UnitOfWork.EntityFramework;
using Pepegov.UnitOfWork.EntityFramework.Repository;
using Service.TemplateController.DAL.Application;

namespace Service.TemplateController.BL.Services.Base;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IEntity
{
    protected readonly IRepositoryEntityFramework<TEntity> Repository;
    private readonly ILogger<BaseService<TEntity>> _logger;
    protected readonly IUnitOfWorkEntityFrameworkInstance UnitOfWork;

    public BaseService(UnitOfWorkManager unitOfWork, ILogger<BaseService<TEntity>> logger)
    {
        _logger = logger;
        UnitOfWork = unitOfWork.GetInstance<IUnitOfWorkEntityFrameworkInstance>();
        Repository = UnitOfWork.GetRepository<TEntity>();
    }

    public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            Repository.Delete(id);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return UnitOfWork.LastSaveChangesResult.IsOk;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Произошла ошибка при удалении сущности {nameof(TEntity)} c id {id}: {e.Message}");
            throw;
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        return await Repository.GetFirstOrDefaultAsync(predicate: item => item.Id == id, include: include, cancellationToken: cancellationToken);
    }

    public virtual async Task<IPagedList<TEntity>> GetPagedListAsync(int page, int pageSize = 20, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default)
    {
        return await Repository.GetPagedListAsync(pageIndex: page, pageSize: pageSize, include: include, cancellationToken: cancellationToken);
    }

    public Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        return GetAllAsync(predicate: null, include: include, cancellationToken: cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        return await Repository.GetAllAsync(predicate: predicate, include: include, cancellationToken: cancellationToken);

    }

    public virtual async Task<TEntity?> Create(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            var entry = await Repository.InsertAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            if (UnitOfWork.LastSaveChangesResult.IsOk)
            {
                return entry.Entity;
            }

            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Произошла ошибка при создание сущности {nameof(TEntity)}: {e.Message}");
            throw;
        }
    }

    public virtual async Task<bool?> Create(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        try
        {
            await Repository.InsertAsync(entities, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return UnitOfWork.LastSaveChangesResult.IsOk;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Произошла ошибка при создание сущностей {nameof(TEntity)}: {e.Message}");
            throw;
        }
    }

    public virtual async Task<bool> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        try
        {
            Repository.Update(entities);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return UnitOfWork.LastSaveChangesResult.IsOk;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Произошла ошибка при обновление сущностей {nameof(TEntity)}: {e.Message}");
            throw;
        }
    }

    public virtual async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            Repository.Update(entity);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Произошла ошибка при обновление сущности {nameof(TEntity)}: {e.Message}");
            throw;
        }
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Repository.ExistsAsync(selector: predicate, cancellationToken: cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetByListIdsAsync(IEnumerable<Guid> ids, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        return await GetAllAsync(predicate: item => ids.Contains(item.Id), include: include, cancellationToken: cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int? count = null,
        CancellationToken cancellationToken = default)
    {
        return await Repository.GetAllAsync(predicate: predicate, include: include, cancellationToken:cancellationToken);

    }
}