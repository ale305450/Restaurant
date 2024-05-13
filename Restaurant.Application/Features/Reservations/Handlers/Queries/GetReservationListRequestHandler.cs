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
    public class GetReservationListRequestHandler : IRequestHandler<GetReservationListRequest, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationListRequestHandler(IReservationRepository reservationRepository,IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<List<ReservationDto>> Handle(GetReservationListRequest request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAll();
            return _mapper.Map<List<ReservationDto>>(reservations);
        }
    }
}
