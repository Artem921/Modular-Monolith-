using Carts.Domain.Abstraction;
using MediatR;

namespace Carts.Application.Carts.Commands.DeleteCart
{
    internal class DeleteCartHander : IRequestHandler<DeleteCartCommand>
    {
        private readonly ICacheService cacheService;

        public DeleteCartHander(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => cacheService.ClearCachedData(request.Id));
        }
    }
}
