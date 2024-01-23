using System;
using System.Collections.Generic;

namespace GeradorCertificados.Models;

public class Aluno
{
    public int AlunoId { get; set; }
    public string Nome { get; set; }
    public int Matricula { get; set; }
    public virtual ICollection<Evento> Eventos { get; set; }
}