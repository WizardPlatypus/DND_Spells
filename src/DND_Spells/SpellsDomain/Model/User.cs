using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class User : Entity
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public byte StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;
}
