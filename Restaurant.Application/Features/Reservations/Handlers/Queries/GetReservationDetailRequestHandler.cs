using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.Features.Reservations.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Reservations.Handlers.Queries
{
    public class GetReservationDetailRequestHandler : IRequestHandler<GetReservationDetailRequest, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationDetailRequestHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(GetReservationDetailRequest request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.Get(request.Id);
            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
