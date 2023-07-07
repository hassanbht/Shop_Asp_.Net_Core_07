﻿namespace Asp07Store.ShopUI.Models;

public class EfProductRepository : IProductRepository
{
    private readonly StoreDbContext storeDbContext;

    public EfProductRepository(StoreDbContext storeDbContext)
    {
        this.storeDbContext = storeDbContext;
    }



    public PagedData<Product> GetAll(int pageNumber, int pageSize, string category)
    {
        var result = new PagedData<Product>
        {
            PageInfo = new PageInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber
            }
        };

        var list = storeDbContext.Products.ToList();
        result.Data = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category!.Name == category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        result.PageInfo.TotalCount = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category!.Name == category).Count();
        return result;
    }



    public Product? GetById(int id)
    {
        return storeDbContext.Products.FirstOrDefault(p => p.Id == id);
    }
}
