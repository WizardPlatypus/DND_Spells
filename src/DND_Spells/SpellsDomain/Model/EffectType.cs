using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class EffectType : Entity
{
    public int EffectTypeId { get; set; }

    public string Label { get; set; } = null!;
}
