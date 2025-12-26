using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bed_grooming_app.domain.EntityModel
{
    [Table("Client")]
    public class ClientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientId { get; set; }

        [ForeignKey("PersonId")]
        public long PersonId { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;

    }
}
