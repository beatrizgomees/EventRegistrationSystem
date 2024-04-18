namespace ativa_recife.Exception;

using System;

public class AppDbContextNotInitializedException : Exception
{
    public AppDbContextNotInitializedException() : base("O contexto do banco de dados não foi inicializado.") { }

    public AppDbContextNotInitializedException(string message) : base(message) { }

    public AppDbContextNotInitializedException(string message, Exception innerException) : base(message, innerException) { }
}
