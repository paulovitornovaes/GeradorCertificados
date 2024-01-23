using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorCertificados.Models;

public class Evento
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //[Column("EventoId")]
    public int EventoId { get; set; }
    public string EventoTitulo { get; set; }
    public ICollection<Aluno> Alunos { get; set; }
}