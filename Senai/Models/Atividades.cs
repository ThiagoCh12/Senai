using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Senai.Models
{
    [Table("Atividades")]
    public class Atividades
    {
        [Key]
        public int id { get; set; }
        [MaxLength(255)]
        public string nome { get; set; }
        [ForeignKey("Turma")]
        public int id_turma { get; set; }
        public Turmas Turma { get; set; }
    }
}
