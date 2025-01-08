﻿using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AppUserDtos;
using Restaurant.BLL.Dtos.OrderItemDtos;
using Restaurant.BLL.Dtos.StatusDtos;

namespace Restaurant.BLL.Dtos.OrderDtos
{
    public class OrderGetDto : IDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } = null!;
        public List<OrderItemGetDto> OrderItems { get; set; } = [];
        public decimal TotalPrice { get; set; }
        public StatusGetDto Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserGetDto AppUser { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
