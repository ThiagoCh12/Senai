using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Key]
        public int id { get; set; }

        [MaxLength(100)]
        public string nome { get; set; }

        [MaxLength(100)]
        public string email { get; set; }

        public string senha { get; set; }
    }
}
