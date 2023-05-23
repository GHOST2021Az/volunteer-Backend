using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace volunteer.Models;

[Table("commentPost")]
public partial class CommentPost
{
    [Key]
    [Column("PostCommentID")]
    public int PostCommentId { get; set; }

    [Column("comment_describt")]
    [StringLength(40)]
    public string? CommentDescribt { get; set; }

    [Column("approvedPostID")]
    public int ApprovedPostId { get; set; }

    [Column("commentby")]
    [StringLength(40)]
    public string Commentby { get; set; } = null!;

    [Column("createdate", TypeName = "smalldatetime")]
    public DateTime? Createdate { get; set; }

    [ForeignKey("ApprovedPostId")]
    [InverseProperty("CommentPosts")]
    public virtual Aprovedpost ApprovedPost { get; set; } = null!;
}
