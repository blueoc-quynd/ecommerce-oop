using ECommerceOOP.ECommerceOOP.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOOP.ECommerceOOP.Repository;

// Generic implementation: 1 class xử lý CRUD cho tất cả entity
public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public void Save(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }
}
