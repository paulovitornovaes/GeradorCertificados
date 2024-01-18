using GeradorCertificados.Services.Contracts;
using System.Globalization;
using CsvHelper;
using GeradorCertificados.Data;
using GeradorCertificados.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GeradorCertificados.Services;

public class CargaService : ICargaService
{
    private readonly BaseDbContext _context;
    
    public CargaService(BaseDbContext context)
    {
        _context = context;
    }
    
    public void carregarCarga(string csvFilePath, string tituloEvento)
    {
        try
        {
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
            var carga = new Evento()
            {
                Nome = nome,
                Matricula = int.Parse(matricula),
                EventoTitulo = tituloEvento
            };
            _context.Evento.Add(carga);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}