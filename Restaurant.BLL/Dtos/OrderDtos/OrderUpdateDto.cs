﻿using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.OrderItemDtos;

namespace Restaurant.BLL.Dtos.OrderDtos
{
    public class OrderUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? Apartment { get; set; }
        public string? CompanyName { get; set; }
        public string Street { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<OrderItemUpdateDto> OrderItems { get; set; } = [];
    }
}
