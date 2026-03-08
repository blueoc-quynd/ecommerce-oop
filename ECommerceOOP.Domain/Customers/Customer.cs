namespace ECommerceOOP.ECommerceOOP.Domain.Customers;

// Encapsulation: Name chỉ được gán qua constructor, bảo vệ dữ liệu
// Inheritance: lớp con kế thừa và phải override GetDiscount()
public abstract class Customer(string name)
{
    public string Name { get; } = name;

    // Polymorphism: mỗi loại customer trả về mức discount khác nhau
    public abstract decimal GetDiscount();
}
