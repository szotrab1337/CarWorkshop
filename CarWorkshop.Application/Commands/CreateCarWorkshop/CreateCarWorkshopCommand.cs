using CarWorkshop.Application.CarWorkshop;
using MediatR;

namespace CarWorkshop.Application.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommand : CarWorkshopDto, IRequest
    {
    }
}
