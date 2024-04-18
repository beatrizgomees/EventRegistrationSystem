namespace ativa_recife.Exception;
using System;
public class NotFoundException : Exception
{
    public NotFoundException() : base("Recurso não encontrado.") { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
}