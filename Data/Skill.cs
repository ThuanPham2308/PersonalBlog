using System;
using System.Collections.Generic;

namespace PersonalBlog.Data;

public partial class Skill
{
    public int Id { get; set; }

    public string SkillName { get; set; } = null!;

    public byte? Proficiency { get; set; }
}
