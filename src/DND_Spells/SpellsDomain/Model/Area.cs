using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class Area : Entity
{
    public int AreaTypeId { get; set; }

    [Display(Name = "Розмір")]
    public int AreaSize { get; set; }

    [Display(Name = "Фігура")]
    public virtual AreaType AreaType { get; set; } = null!;

    public virtual Spell? Spell { get; set; }
}
