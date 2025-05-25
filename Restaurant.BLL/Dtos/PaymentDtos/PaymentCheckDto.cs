using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Dtos;

public class PaymentCheckDto : IDto
{
    public string Token { get; set; } = null!;
    public int ID { get; set; }
    public PaymentStatuses STATUS { get; set; }
}

public class PaymentConfigurationDto : IDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
}

public class PaymentCreateDto : IDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
    public int OrderId { get; set; }
}


public class PaymentGetDto : IDto
{
    public int OrderId { get; set; }
    public int ReceptId { get; set; }
    public string SecretId { get; set; } = null!;
    public PaymentStatuses PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}


public class PaymentResponseDto : IDto
{
    public OrderDto Order { get; set; } = null!;
    public int Id { get; set; }
}

public class OrderDto : IDto
{
    public int Id { get; set; }
    public string Password { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string HppUrl { get; set; } = null!;
    public string Cvv2AuthStatus { get; set; } = null!;
    public string Secret { get; set; } = null!;
}
