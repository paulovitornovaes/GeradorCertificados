using System.Globalization;
using CsvHelper;
using GeradorCertificados2.Data;
using GeradorCertificados2.Models;
using Microsoft.AspNetCore.Mvc;


namespace GeradorCertificados2.Controllers;

[ApiController]
[Route("[controller]")]
public class CargaController : Controller
{
 
    private readonly BaseDbContext _context;

    public CargaController(BaseDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Aluno>> Get()
    {
        // Substitua "SeuModelo" pelo nome da sua classe de modelo que representa os dados do CSV

        // Caminho do arquivo CSV (ajuste conforme necessário)
        string csvFilePath = "Caminho/Para/Seu/Arquivo.csv";

        try
        {
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Aluno>().ToList();
            return Ok(records);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao ler o arquivo CSV: {ex.Message}");
        }
    }
}