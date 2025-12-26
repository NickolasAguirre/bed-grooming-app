using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bed_grooming_app.domain.EntityModel
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [ForeignKey("Perfil")]
        public long PerfilId { get; set; }

        [ForeignKey("Person")]
        public long PersonId { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public int CountRecoveredPassword { get; set; } = 0;
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;
    }
}
