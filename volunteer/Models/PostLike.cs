using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace volunteer.Models;

[Table("postLIKE")]
public partial class PostLike
{
    [Key]
    [Column("likepostID")]
    public int LikepostId { get; set; }

    [Column("approvedpostID")]
    public int? ApprovedpostId { get; set; }

    [Column("createtime", TypeName = "date")]
    public DateTime? Createtime { get; set; }
}
