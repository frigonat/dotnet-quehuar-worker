using System;

namespace dotnet_quehuar_worker.Domain.Exceptions;

public class AdAccountInvalidException : Exception
{
    public AdAccountInvalidException(string adAccount, Exception ex)
        : base($"AD Account \"{adAccount}\" is invalid.", ex)
    {
    }
}
