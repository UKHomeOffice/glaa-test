using System.ComponentModel.DataAnnotations;

namespace GlaaCore.Domain.Models
{
    public class Licence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Application ID")]
        public string ApplicationId { get; set; }
        [Required]
        [Display(Name = "Organisation Name")]
        public string OrganisationName { get; set; }
    }
}
