using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class AttackType : Entity
{
    [Display(Name = "Атака")]
    public string Label { get; set; } = null!;
}
