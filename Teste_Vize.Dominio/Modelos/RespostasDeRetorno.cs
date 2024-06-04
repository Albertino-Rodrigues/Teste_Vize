namespace Teste_Vize.Dominio.Modelos;

public class RespostasDeRetorno<T>
{
    public bool Sucesso {  get; set; }
    public string Mensagem { get; set;}
    public T Dados { get; set; }

    public static RespostasDeRetorno<T> SucessoNoRetorno(T dados, string mensagem)
    {
        return new RespostasDeRetorno<T> { Sucesso = true, Dados = dados, Mensagem = mensagem };
    }

    public static RespostasDeRetorno<T> FalhaNoRetorno(string mensagem)
    {
        return new RespostasDeRetorno<T> { Sucesso = false, Mensagem = mensagem };
    }
}