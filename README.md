# C# Advanced OOP Homework  
## E-Commerce Order & Payment System

## Mục tiêu

Bài tập này nhằm giúp bạn:

- Áp dụng đúng 4 tính chất của OOP:
  - Encapsulation
  - Abstraction
  - Inheritance
  - Polymorphism
- Áp dụng các nguyên tắc SOLID (đặc biệt OCP & DIP)
- Thiết kế hệ thống có khả năng mở rộng
- Tách rõ Dependency bằng Constructor Injection


# YÊU CẦU CHI TIẾT

Bạn cần thiết kế một hệ thống xử lý **Order** cho một ứng dụng thương mại điện tử.

Hệ thống cần hỗ trợ:

- Nhiều loại Payment Method
- Nhiều loại Customer (có discount khác nhau)
- Cơ chế tính Discount theo từng loại Customer
- Logging khi thực hiện Checkout
- Có thể mở rộng mà không sửa code cũ


# YÊU CẦU THIẾT KẾ

- Không sử dụng if/switch dựa trên type
- Không hardcode dependency
- Áp dụng các nguyên tắc của OOP
- Code phải mở rộng được mà không sửa class Order

# CÂU HỎI BẮT BUỘC TRẢ LỜI

1. Code của bạn đang áp dụng những nguyên tắc SOLID nào?
2. Nếu thêm 1 hoặc nhiều loại payment, customer, logger thì phải xử lý như thế nào?
→ Có phải sửa Order không? Vì sao?
3. Nếu bỏ interface IPaymentMethod thì có vấn đề gì?

# NỘP BÀI
1. Source code: Mọi người folk ra repo của mình và tạo Pull Request sang main repo.
2. UML diagram đơn giản
3. Giải thích design