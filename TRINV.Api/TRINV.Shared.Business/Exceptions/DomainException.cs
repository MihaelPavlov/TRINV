using TRINV.Shared.Business.Exceptions.Interfaces;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Shared.Business.Exceptions;

public class DomainException : IError
{
    public DomainException(string? customMessage = null)
        : base(ErrorCode.Domain.ToString(), (int)ErrorCode.BadRequest, "Domain exception occure")
    {
        this.Message = customMessage ?? this.Message;
    }
}
