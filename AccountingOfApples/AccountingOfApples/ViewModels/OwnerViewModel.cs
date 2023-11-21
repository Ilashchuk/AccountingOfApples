﻿using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class OwnerViewModel
{
    public Guid? Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public int Percent { get; set; }
}
