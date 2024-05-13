using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Reservation.Validators;
using Restaurant.Application.Features.Reservations.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Reservations.Handlers.Commands
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, BaseCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateReservationDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateReservationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Reservation update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var reservation = await _reservationRepository.Get(request.Id);
            if (request.UpdateReservationDto != null)
            {
                _mapper.Map(request.UpdateReservationDto, reservation);

                await _reservationRepository.Update(reservation);
            }
            else if (request.ChangeReservationStatusDto != null)
            {
                await _reservationRepository.ChangeReservationStatus(reservation, request.ChangeReservationStatusDto.Status);
            }

            response.Success = true;
            response.Message = "Reservation updated successfully";
            response.Id = reservation.Id;

            return response;
        }
    }
}
