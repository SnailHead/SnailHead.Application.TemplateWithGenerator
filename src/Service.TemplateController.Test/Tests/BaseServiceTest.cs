using Pepegov.UnitOfWork.EntityFramework;
using Pepegov.UnitOfWork.EntityFramework.Repository;
using Service.TemplateController.BL.Services.Base;
using Service.TemplateController.DAL.Application;
using Service.TemplateController.Test.MockData;

namespace Service.TemplateController.Test.Tests;

public abstract class BaseServiceTest<TEntity> where TEntity: class, IEntity, new()
{
    protected IBaseService<TEntity> BaseService = null!;
    protected IUnitOfWorkEntityFrameworkInstance UnitOfWorkEntityFrameworkInstance = null!;
    protected IRepositoryEntityFramework<TEntity> Repository = null!;
    protected MockBase<TEntity> Mock = null!;
	
    protected async Task CreateEntity_Success()
    {
        var entity = await CreateEntity();
        var result = await BaseService.CreateAsync(entity, new CancellationToken());
        Assert.That(result is not null, Is.True);
        result = await BaseService.GetByIdAsync(result.Id);
        Assert.That(result is not null, Is.True, $"Create {typeof(TEntity).Name} is success");
        await BaseService.DeleteAsync(result.Id);
    }
	
    protected async Task DeleteEntity_Success()
    {
        var entity = await BaseService.CreateAsync(await CreateEntity(), new CancellationToken());
        var result = await BaseService.DeleteAsync(entity.Id);
        Assert.That(result, Is.True, $"Delete {typeof(TEntity).Name} is success");
    }
    protected async Task GetPaged_Success()
    {
        const int pageSize = 10; 
        const int totalCount = 20; 
        var array = await CreateEntity(totalCount);
        if (!await BaseService.CreateAsync(array))
        {
            Assert.Fail();
        }
        var result = await BaseService.GetPagedListAsync(1, pageSize);
        Assert.Multiple(() =>
        {
            Assert.That(result.Items, Has.Count.EqualTo(pageSize), $"Count {typeof(TEntity).Name} items equals {pageSize}");
            //Assert.That(result.TotalCount == totalCount, Is.True, $"TotalCount {typeof(TEntity).Name} items equals {totalCount}");
            Assert.That(result.PageIndex, Is.EqualTo(0), $"PageIndex {typeof(TEntity).Name} items equals 1");
            Assert.That(result.PageSize, Is.EqualTo(pageSize), $"PageSize {typeof(TEntity).Name} items equals {pageSize}");
        });
        await BaseService.DeleteAsync(array);
    }

    protected async Task<TEntity> CreateEntity()
    {
        return await Mock.Create();
    }
    protected async Task<TEntity[]> CreateEntity(int count)
    {
        return await Mock.CreateMany(count);
    }
}