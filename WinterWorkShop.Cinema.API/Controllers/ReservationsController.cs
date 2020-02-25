using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinterWorkShop.Cinema.API.Models;
using WinterWorkShop.Cinema.Domain.Interfaces;
using WinterWorkShop.Cinema.Domain.Models;

namespace WinterWorkShop.Cinema.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        /// <summary>
        /// Gets all reservations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<ReservationDomainModel>>> GetAsync()
        {
            IEnumerable<ReservationDomainModel> reservationDomainModels;

            reservationDomainModels = await _reservationService.GetAllAsync();

            if (reservationDomainModels == null)
            {
                reservationDomainModels = new List<ReservationDomainModel>();
            }

            return Ok(reservationDomainModels);
        }

        /// <summary>
        /// Adds a new reservation
        /// </summary>
        /// <param name="createReservationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("create")]
        public async Task<ActionResult<ReservationDomainModel>> PostAsync(CreateReservationModel createReservationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!createReservationModel.payment)
            {
                ModelState.AddModelError(nameof(createReservationModel.payment), createReservationModel.message);
                return BadRequest(ModelState);
            }

            ReservationDomainModel domainModel = new ReservationDomainModel
            {
                UserId = createReservationModel.userId,                
                ProjectionId = createReservationModel.projectionId,
                SeatId = createReservationModel.seatId,
                Payment = createReservationModel.payment,
                Message = createReservationModel.message
            };

            CreateReservationResultModel createReservationResultModel;

            try
            {
                createReservationResultModel = await _reservationService.CreateReservation(domainModel);
            }
            catch (DbUpdateException e)
            {
                ErrorResponseModel errorResponse = new ErrorResponseModel
                {
                    ErrorMessage = e.InnerException.Message ?? e.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return BadRequest(errorResponse);
            }

            if (!createReservationResultModel.IsSuccessful)
            {
                ErrorResponseModel errorResponse = new ErrorResponseModel
                {
                    ErrorMessage = createReservationResultModel.ErrorMessage,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return BadRequest(errorResponse);
            }

            return Created("reseravtions//" + createReservationResultModel.Reservation.Id, createReservationResultModel.Reservation);
        }
    }
}