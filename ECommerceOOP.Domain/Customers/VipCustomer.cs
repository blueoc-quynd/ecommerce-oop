namespace ECommerceOOP.ECommerceOOP.Domain.Customers;

// Khách VIP: discount 20%
public class VipCustomer(string name) : Customer(name)
{
    public override decimal GetDiscount() => 0.20m;
}
