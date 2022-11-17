using System.ComponentModel.DataAnnotations;

namespace Candidatures.ViewModels
{
    public class CandidatureViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Saisir votre prénom")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Saisir votre nom")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Saisir votre email")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Saisir votre téléphone")]
        [Display(Name = "Téléphone")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Saisir votre niveau d’étude")]
        [Display(Name = "Niveau d’étude")]
        public string LevelOfStudy { get; set; }

        [Display(Name = "Nombre d’années d’expérience")]
        public int NumberOfYearsOfExperience { get; set; }

        [Display(Name = "Dernier employeur")]
        public string LastEmployer { get; set; }

        [Required(ErrorMessage = "Uploader votre cv")]
        [Display(Name = "Uploader votre cv avec le format (PDF ou IMG)")]
        public IFormFile CVFile{ get; set; }
    }
}
