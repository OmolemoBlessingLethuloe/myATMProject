using System.ComponentModel.DataAnnotations;

namespace MyATMProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}