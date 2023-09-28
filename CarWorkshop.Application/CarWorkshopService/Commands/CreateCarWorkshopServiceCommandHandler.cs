﻿using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;

        public CreateCarWorkshopServiceCommandHandler(
            IUserContext userContext,
            ICarWorkshopRepository carWorkshopRepository,
            ICarWorkshopServiceRepository carWorkshopServiceRepository)
        {
            _userContext = userContext;
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }

        public async Task Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                throw new InvalidOperationException();
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkshop.Id
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);
        }
    }
}
