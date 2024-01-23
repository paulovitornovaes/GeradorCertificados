using GeradorCertificados.Services.Contracts;
using System.Globalization;
using CsvHelper;
using System.Linq;
using GeradorCertificados.Data;
using GeradorCertificados.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GeradorCertificados.Services;

public class CargaService : ICargaService
{
    private readonly BaseDbContext _context;
    private readonly IEventoService _eventoService;
    
    public CargaService(BaseDbContext context, IEventoService eventoService)
    {
        _context = context;
        _eventoService = eventoService;
    }
    
    public void carregarCarga(string csvFilePath, string tituloEvento)
    {
        try
        {
            var eventoId = _eventoService.criarEvento(tituloEvento);
            
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            //csv.Configuration.HasHeaderRecord = true; // Indica que o CSV tem cabeçalho
            var records = csv.GetRecords<dynamic>().ToList();
            
            //var nome = "";
            //var matricula = "";
            
            foreach (var record in records)
            {
                var nome = record.Nome;
                var matricula = record.Matricula;
                mapearRegistroCarga(nome, matricula, tituloEvento);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo CSV: {ex.Message}");
        }
    }

    private void mapearRegistroCarga(string nome, string matricula, string tituloEvento)
    {
        try
        {
            /*
            var carga = new Evento()
            {
                Nome = nome,
                Matricula = int.Parse(matricula),
                EventoTitulo = tituloEvento
            };
            */
            //_context.Evento.Add(carga);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<int> ObterOuCriarAluno(string nome, string matricula)
    {
        var alunoExistente = await _context.Aluno.FirstOrDefaultAsync(a => a.Matricula == int.Parse(matricula));
        
        if (alunoExistente != null)
        {
            return alunoExistente.AlunoId;
        }

        var novoAluno = new Aluno()
        {
            Nome = nome,
            Matricula = int.Parse(matricula)
        };

        await _context.Aluno.AddAsync(novoAluno);
        await _context.SaveChangesAsync();

        return novoAluno.AlunoId;
    }
}