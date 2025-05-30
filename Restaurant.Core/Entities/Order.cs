﻿using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities;

public class Order : BaseAuditableEntity
{
    public AppUser? AppUser { get; set; } = null!;
    public string? AppUserId { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Apartment { get; set; }
    public string? CompanyName { get; set; }
    public string Street { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;
    public bool IsPaid { get; set; }

}
