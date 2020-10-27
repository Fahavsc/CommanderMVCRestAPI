using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required(ErrorMessage="O campo line é obrigatório")]
        public string Line { get; set; }

        [Required(ErrorMessage="O campo Platform é obrigatório")]
        public string Platform { get; set; }
    }
}