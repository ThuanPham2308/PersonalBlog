using System;
using System.Collections.Generic;

namespace PersonalBlog.Data;

public partial class Service
{
    public int Id { get; set; }

    public string? ServiceName { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }
}
