﻿using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class DurationType : Entity
{
    public int Value { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Duration> Durations { get; set; } = new List<Duration>();
}
