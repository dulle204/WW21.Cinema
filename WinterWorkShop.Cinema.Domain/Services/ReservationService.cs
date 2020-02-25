using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinterWorkShop.Cinema.Domain.Common;
using WinterWorkShop.Cinema.Domain.Interfaces;
using WinterWorkShop.Cinema.Domain.Models;
using WinterWorkShop.Cinema.Repositories;

namespace WinterWorkShop.Cinema.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IProjectionsRepository _projectionsRepository;
        private readonly ISeatsRepository _seatsRepository;
        

        public ReservationService(IReservationsRepository reservationsRepository, IUsersRepository usersRepository,
                                    IProjectionsRepository projectionsRepository, ISeatsRepository seatsRepository)
        {
            _reservationsRepository = reservationsRepository;
            _usersRepository = usersRepository;
            _projectionsRepository = projectionsRepository;
            _seatsRepository = seatsRepository;
        }

        public async Task<IEnumerable<ReservationDomainModel>> GetAllAsync()
        {
            var data = await _reservationsRepository.GetAll();

            if (data == null)
            {
                return null;
            }

            List<ReservationDomainModel> result = new List<ReservationDomainModel>();
            ReservationDomainModel model;
            foreach (var item in data)
            {
                model = new ReservationDomainModel
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    ProjectionId = item.ProjectionId,
                    SeatId = item.SeatId,
                    Payment = item.Payment,
                    Message = item.Message
                };
                result.Add(model);
            }

            return result;
        }

        public async Task<CreateReservationResultModel> CreateReservation(ReservationDomainModel domainModel)
        {
            var userExist = _usersRepository.GetByIdAsync(domainModel.UserId);
            if (userExist == null) 
            {
                return new CreateReservationResultModel
                {
                    IsSuccessful = false,
                    ErrorMessage = Messages.RESERVATION_CREATION_USERID_ERROR
                };
            }

            var projectionExist = _projectionsRepository.GetByIdAsync(domainModel.ProjectionId);
            if (projectionExist == null)
            {
                return new CreateReservationResultModel
                {
                    IsSuccessful = false,
                    ErrorMessage = Messages.RESERVATION_CREATION_PROJECTIONID_ERROR
                };
            }

            var seatExist = _seatsRepository.GetByIdAsync(domainModel.SeatId);
            if (seatExist == null)
            {
                return new CreateReservationResultModel
                {
                    IsSuccessful = false,
                    ErrorMessage = Messages.RESERVATION_CREATION_SEATID_ERROR
                };
            }

            var newReservation = new Data.Reservation
            {
                UserId = domainModel.UserId,
                ProjectionId = domainModel.ProjectionId,
                SeatId = domainModel.SeatId,
                Payment = domainModel.Payment,
                Message = domainModel.Message
            };

            var insertedReservation = _reservationsRepository.Insert(newReservation);

            if (insertedReservation == null)
            {
                return new CreateReservationResultModel
                {
                    IsSuccessful = false,
                    ErrorMessage = Messages.RESERVATION_CREATION_ERROR
                };
            }

            _reservationsRepository.Save();

            CreateReservationResultModel result = new CreateReservationResultModel
            {
                IsSuccessful = true,
                ErrorMessage = null,
                Reservation = new ReservationDomainModel
                {
                    Id = insertedReservation.Id,
                    UserId = insertedReservation.UserId,
                    ProjectionId = insertedReservation.ProjectionId,
                    SeatId = insertedReservation.SeatId,
                    Payment = insertedReservation.Payment,
                    Message = insertedReservation.Message,                    
                }
            };

            return result;
        }

       
    }
}
