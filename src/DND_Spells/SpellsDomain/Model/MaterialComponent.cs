using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpellsDomain.Model;

public partial class MaterialComponent : Entity
{
    public int SpellId { get; set; }

    public int MaterialTypeId { get; set; }

    [Display(Name = "Вартість")]
    public int WorthCopper { get; set; }

    [Display(Name = "Знищується")]
    public bool Consumed { get; set; }

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
