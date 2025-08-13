using System;
using System.Collections.Generic;

namespace PersonalBlog.Data;

public partial class Education
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? StartYear { get; set; }

    public string? EndYear { get; set; }
}
