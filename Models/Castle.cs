using System.ComponentModel.DataAnnotations;

namespace castles.Models
{
    public class Castle
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int YearBuilt { get; set; }
        [Required]
        public int TimesInvaded { get; set; }
        
        public string ImgUrl { get; set; }
    }
}