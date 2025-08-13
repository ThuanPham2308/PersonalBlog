using System;
using System.Collections.Generic;

namespace PersonalBlog.Data;

public partial class About
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Bio { get; set; }

    public string? ProfileImage { get; set; }

    public string? Job { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Github { get; set; }

    public string? Facebook { get; set; }

    public string? Instagram { get; set; }

    public string? Linkedin { get; set; }

    public string? Email { get; set; }

    public string? Degree { get; set; }

    public string? City { get; set; }

    public string? Freelance { get; set; }

    public string? Phone { get; set; }

    public int? Age { get; set; }
}
