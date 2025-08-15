using System;
using System.Collections.Generic;

namespace PersonalBlog.Data;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Tag { get; set; }

    public string? Content { get; set; }

    public string? Summary { get; set; }

    public DateOnly? PublishDate { get; set; }
}
