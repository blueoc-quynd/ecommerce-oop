namespace ECommerceOOP.ECommerceOOP.Repository;

// Generic interface: dùng cho BẤT KỲ entity nào, không cần viết lại
// T phải là class (entity) — constraint đảm bảo type-safe
public interface IRepository<T> where T : class
{
    void Save(T entity);
    T? GetById(int id);
    List<T> GetAll();
}
