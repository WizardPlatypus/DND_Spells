using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class MaterialType : Entity
{
    [Display(Name = "Назва")]
    public string Label { get; set; } = null!;
}
