using Service.TemplateController.DAL.Application;

namespace Service.TemplateController.Test.MockData.Interface;

public interface IMockBase<TEntity>where TEntity: class, IEntity, new()
{
    public abstract Task<TEntity> Create(Guid? id = null);
    public abstract Task<TEntity[]> CreateMany(int count = 10);
}