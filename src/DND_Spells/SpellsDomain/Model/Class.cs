using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Class : Entity
{
    public int ClassId { get; set; }

    public string Label { get; set; } = null!;
}
