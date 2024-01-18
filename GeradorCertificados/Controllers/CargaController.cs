using System.Globalization;
using CsvHelper;
using GeradorCertificados.Data;
using GeradorCertificados.Models;
using GeradorCertificados.Services.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace GeradorCertificados.Controllers;

[ApiController]
[Route("[controller]")]
public class CargaController : Controller
{
 
    private readonly BaseDbContext _context;
    private readonly ICargaService _cargaService;

    public CargaController(BaseDbContext context, ICargaService cargaService)
    {
        _context = context;
        _cargaService = cargaService;
    }
    
    [HttpPost("importarCarga")]
    public ActionResult<IEnumerable<dynamic>> Get([FromForm] string tituloEvento)
    {
        // Caminho do arquivo CSV (ajuste conforme necessário)
        string csvFilePath = "C:\\Users\\paulo\\Documents\\dasi.csv";
        _cargaService.carregarCarga(csvFilePath, tituloEvento);
        return Ok();
    }

}