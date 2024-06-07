using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class EffectType : Entity
{
    [Display(Name = "Ефект")]
    public string Label { get; set; } = null!;
}
