using AutoMapper;
using MediatR;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Reservations.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;

namespace Restaurant.Application.Features.Reservations.Handlers.Commands
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, BaseCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var reservation = await _reservationRepository.Get(request.Id);

            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.Id);

            await _reservationRepository.Delete(reservation);

            response.Success = true;
            response.Message = "User Deleted successfully";
            response.Id = reservation.Id;

            return response;
        }
    }
}
