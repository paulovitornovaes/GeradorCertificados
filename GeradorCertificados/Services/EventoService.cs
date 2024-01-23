using GeradorCertificados.Data;
using GeradorCertificados.Models;
using GeradorCertificados.Services.Contracts;

namespace GeradorCertificados.Services;

public class EventoService : IEventoService
{
    private readonly BaseDbContext _context;
    
    public EventoService(BaseDbContext context)
    {
        _context = context;
    }
    
    public int criarEvento(string tituloEvento)
    {
        var novoEvento = new Evento()
        {
            EventoTitulo = tituloEvento
        };
        _context.Evento.Add(novoEvento);
        _context.SaveChanges();
        
        return novoEvento.EventoId;
    }
}