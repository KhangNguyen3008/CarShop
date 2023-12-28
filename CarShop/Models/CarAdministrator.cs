using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarAdministrator
{
    public string AdminId { get; set; } = null!;

    public string AdminName { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;

    public string? AdminDetail { get; set; }

    public string? AdminEmail { get; set; }

    public virtual ICollection<CarCustomer> CarCustomers { get; set; } = new List<CarCustomer>();
}
