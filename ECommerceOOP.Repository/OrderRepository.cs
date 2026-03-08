using ECommerceOOP.ECommerceOOP.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOOP.ECommerceOOP.Repository;

// Kế thừa Repository<T> để có sẵn CRUD
// Chỉ override hoặc thêm logic đặc thù cho Order
public class OrderRepository(AppDbContext context)
    : Repository<OrderEntity>(context), IOrderRepository
{
    private readonly AppDbContext _context = context;

    // Logic đặc thù: load kèm Items (navigation property)
    public List<OrderEntity> GetAllWithItems()
    {
        return _context.Orders
            .Include(o => o.Items)
            .ToList();
    }
}
