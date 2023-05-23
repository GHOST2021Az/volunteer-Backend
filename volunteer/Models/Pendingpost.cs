using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace volunteer.Models;

[Table("pendingpost")]
public partial class Pendingpost
{
    [Key]
    [Column("pendingpostID")]
    public int PendingpostId { get; set; }

    [Column("postName")]
    [StringLength(40)]
    public string PostName { get; set; } = null!;

    [Column("userID")]
    public int UserId { get; set; }

    [Column("userName")]
    [StringLength(40)]
    public string? UserName { get; set; }

    [StringLength(40)]
    public string? Postdescribtion { get; set; }
}
