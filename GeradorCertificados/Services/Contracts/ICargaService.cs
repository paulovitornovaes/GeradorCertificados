namespace GeradorCertificados.Services.Contracts;

public interface ICargaService
{
    public void carregarCarga(string csvFilePath, string tituloEvento);
}