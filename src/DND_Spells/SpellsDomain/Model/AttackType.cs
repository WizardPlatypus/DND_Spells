﻿using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class AttackType : Entity
{
    public byte AttackTypeId { get; set; }

    public string Label { get; set; } = null!;
}