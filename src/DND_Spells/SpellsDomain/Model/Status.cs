using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Status : Entity
{
    public string Label { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
