using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bed_grooming_app.domain.Entities
{
    [Table("ClientPet")]
    public class ClientPetModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientPetId { get; set; }

        [ForeignKey("Client")]
        public long ClientId { get; set; }

        [ForeignKey("Pet")]
        public long PetId { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;

    }
}
