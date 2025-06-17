using System;
using System.Collections.Generic;

namespace WebAPI_roductManagement.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

}
