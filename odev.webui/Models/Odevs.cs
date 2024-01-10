using System.ComponentModel.DataAnnotations;

namespace OdevPortali.Models
{
    public class Odevs
    {
        [Key]
        public int OdevId { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string Ad { get; set; }
    }
}
