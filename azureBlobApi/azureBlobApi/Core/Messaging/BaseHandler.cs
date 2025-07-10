using MediatR;

namespace azureBlobApi.Core.Messaging;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
{
}
