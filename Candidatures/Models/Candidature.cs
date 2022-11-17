namespace Candidatures.Models
{
    public class Candidature
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LevelOfStudy { get; set; }
        public int NumberOfYearsOfExperience { get; set; }
        public string LastEmployer { get; set; }

    }
}
