using Restaurant.Models.Book;
using Restaurant.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.TestData
{
    public class TestBooking : IRepositoryBooking
    {
        IEnumerable<Booking> bookings = new List<Booking>() { new Booking() {Id=1, Client="Name" } };
        public IEnumerable<Booking> Bookings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(int? id)
        {
            throw new NotImplementedException();
        }

        public void EditBooking(int id, Booking booking)
        {
            
        }

        public Booking GetBooking(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
