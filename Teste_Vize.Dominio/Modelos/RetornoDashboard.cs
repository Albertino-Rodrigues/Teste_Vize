namespace Teste_Vize.Dominio.Modelos;

public class RetornoDashboard
{
    public List<Dashboard> Dados { get; set; }

    public RetornoDashboard()
    {
        Dados = new List<Dashboard>();
    }
}