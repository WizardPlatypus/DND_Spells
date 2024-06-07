using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class User : Entity
{
    public string Login { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;
}
