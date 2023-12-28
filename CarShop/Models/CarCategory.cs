using System;
using System.Collections.Generic;

namespace CarShop.Models;

public partial class CarCategory
{
    public int CatId { get; set; }

    public string CatName { get; set; } = null!;

    public string? CatDetail { get; set; }

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
