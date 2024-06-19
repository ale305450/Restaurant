using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Reservation.Validators;
using Restaurant.Application.Features.Reservations.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Contracts.Infrastructure;
using Restaurant.Application.Models;

namespace Restaurant.Application.Features.Reservations.Handlers.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, BaseCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository,
            IMapper mapper,
            IEmailSender emailSender)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateReservationDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateReservationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Reservation creation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var reservation = _mapper.Map<Reservation>(request.CreateReservationDto);

                reservation = await _reservationRepository.Add(reservation);

                response.Success = true;
                response.Message = "Reservation created successfully";
                response.Id = reservation.Id;

                var email = new Email
                {
                    To = "",
                    Body = $" Your reservation is in {request.CreateReservationDto.Date}  at {request.CreateReservationDto.Time}",
                    Subject = "Table reservation"
                };
                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {

                }
            }
            return response;
        }
    }
}
