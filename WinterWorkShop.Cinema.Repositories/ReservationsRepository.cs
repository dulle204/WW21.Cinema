using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinterWorkShop.Cinema.Data;

namespace WinterWorkShop.Cinema.Repositories
{

    public interface IReservationsRepository : IRepository<Reservation>
    {
    }

    public class ReservationsRepository : IReservationsRepository
    {
        private CinemaContext _cinemaContext;

        public ReservationsRepository(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public Reservation Delete(object id)
        {
            Reservation existing = _cinemaContext.Reservations.Find(id);
            var result = _cinemaContext.Reservations.Remove(existing).Entity;

            return result;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            var data = await _cinemaContext.Reservations.ToListAsync();

            return data;
        }

        public async Task<Reservation> GetByIdAsync(object id)
        {
            return await _cinemaContext.Reservations.FindAsync(id);
        }

        public Reservation Insert(Reservation obj)
        {
            var data = _cinemaContext.Reservations.Add(obj).Entity;

            return data;
        }

        public void Save()
        {
            _cinemaContext.SaveChanges();
        }

        public Reservation Update(Reservation obj)
        {
            var updatedEntry = _cinemaContext.Reservations.Attach(obj).Entity;
            _cinemaContext.Entry(obj).State = EntityState.Modified;

            return updatedEntry;
        }
    }
}
