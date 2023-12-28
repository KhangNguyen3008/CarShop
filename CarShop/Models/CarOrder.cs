using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarOrder
{
    public string OrderId { get; set; } = null!;

    public string OrderName { get; set; } = null!;

    public string? OrderDetail { get; set; }

    public string CarId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public virtual CarProduct Car { get; set; } = null!;

    public virtual ICollection<CarCart> CarCarts { get; set; } = new List<CarCart>();

    public virtual CarCustomer Customer { get; set; } = null!;
}
