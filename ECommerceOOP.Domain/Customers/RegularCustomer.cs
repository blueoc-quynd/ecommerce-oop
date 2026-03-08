namespace ECommerceOOP.ECommerceOOP.Domain.Customers;

// Khách hàng thường: không có discount (0%)
public class RegularCustomer(string name) : Customer(name)
{
    public override decimal GetDiscount() => 0m;
}
