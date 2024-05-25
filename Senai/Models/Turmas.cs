using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Senai.Models
{
    [Table("Turmas")]
    public class Turmas
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string nome_turma { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}
