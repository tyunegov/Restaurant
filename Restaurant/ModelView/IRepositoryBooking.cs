using Restaurant.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ModelView
{
    public interface IRepositoryBooking
    {
       IEnumerable<Booking> Bookings { get; set; }

        void CreateBooking(Booking booking);
        Booking GetBooking(int? id);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int? id);
        void EditBooking(int id, Booking booking);
    }
}
