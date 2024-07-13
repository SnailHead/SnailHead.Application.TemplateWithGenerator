using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pepegov.UnitOfWork;
using Pepegov.UnitOfWork.EntityFramework;
using Service.TemplateController.DAL.Application;
using Service.TemplateController.Test.MockData.Interface;

namespace Service.TemplateController.Test.MockData;

public abstract class MockBase<TEntity> : IMockBase<TEntity> where TEntity: class, IEntity, new()
{
    public abstract Task<TEntity> Create(Guid? id = null);

    public async Task<TEntity[]> CreateMany(int count = 10)
    {
        var array = new TEntity[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = await Create();
        }

        return array;
    }
}