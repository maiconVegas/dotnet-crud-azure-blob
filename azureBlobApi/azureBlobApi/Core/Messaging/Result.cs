using FluentValidation.Results;
using System.Net;

namespace azureBlobApi.Core.Messaging;

public class Result
{
    public ValidationResult ValidationResult { get; set; }
    public HttpStatusCode? ErrorStatusCode { get; set; }
    public bool Sucess => !ErrorStatusCode.HasValue;
}

public class Result<T> : Result
{
    public T Value { get; set; }
}