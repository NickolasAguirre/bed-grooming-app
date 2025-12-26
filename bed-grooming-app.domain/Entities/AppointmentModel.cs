using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bed_grooming_app.domain.EntityModel
{
    [Table("Appointment")]
    public class AppointmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AppointmentId { get; set; }

        [ForeignKey("Client")]
        public long ClienteId { get; set; }

        [ForeignKey("Pet")]
        public long PetId { get; set; }

        [ForeignKey("Service")]
        public long ServiceId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string? AppointmentStateCode { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;
    }
}
