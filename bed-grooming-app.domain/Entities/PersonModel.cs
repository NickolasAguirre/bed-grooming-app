using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bed_grooming_app.domain.EntityModel
{
    [Table("Person")]
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonId { get; set; }
        public required string FirstName { get; set; }
        public required string FatherLastName { get; set; }
        public required string MotherLastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;
        public string FullName => $"{this.FirstName} {this.FatherLastName} {this.MotherLastName}";
    }
}
