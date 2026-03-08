using ECommerceOOP.ECommerceOOP.Entity;

namespace ECommerceOOP.ECommerceOOP.Repository;

// Kế thừa IRepository<T> để có sẵn Save, GetById, GetAll
// Chỉ thêm method đặc thù cho Order (nếu có)
public interface IOrderRepository : IRepository<OrderEntity>
{
    List<OrderEntity> GetAllWithItems();
}
