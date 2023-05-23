using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace volunteer.Models;

[Table("aprovedposts")]
public partial class Aprovedpost
{
    [Key]
    [Column("approvedPostID")]
    public int ApprovedPostId { get; set; }

    [StringLength(50)]
    public string? Postname { get; set; }

    [Column("adminID")]
    public int AdminId { get; set; }

    [StringLength(50)]
    public string? Approvedby { get; set; }

    [Column("postdescribtion")]
    [StringLength(50)]
    public string? Postdescribtion { get; set; }

    [Column("createDate", TypeName = "smalldatetime")]
    public DateTime? CreateDate { get; set; }

    [InverseProperty("ApprovedPost")]
    public virtual ICollection<CommentPost> CommentPosts { get; set; } = new List<CommentPost>();
}
