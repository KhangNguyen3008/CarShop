using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarCustomer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string? CustomerEmail { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CusormerImage { get; set; }

    public string? CustomerPhone { get; set; }

    public string AdminId { get; set; } = null!;

    public virtual CarAdministrator Admin { get; set; } = null!;

    public virtual ICollection<CarOrder> CarOrders { get; set; } = new List<CarOrder>();
}
