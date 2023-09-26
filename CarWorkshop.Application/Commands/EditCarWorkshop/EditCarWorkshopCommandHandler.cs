﻿using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _repository;
        private readonly IUserContext _userContext;

        public EditCarWorkshopCommandHandler(ICarWorkshopRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                throw new InvalidOperationException();
            }

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.Street = request.Street;

            await _repository.Commit();
        }
    }
}
