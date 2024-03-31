using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class MaterialComponent : Entity
{
    public int SpellId { get; set; }

    public int MaterialTypeId { get; set; }

    public int WorthCopper { get; set; }

    public bool Consumed { get; set; }

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
