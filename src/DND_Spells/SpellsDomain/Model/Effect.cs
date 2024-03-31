using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Effect : Entity
{
    public int SpellId { get; set; }

    public byte EffectTypeId { get; set; }

    public virtual EffectType EffectType { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}
