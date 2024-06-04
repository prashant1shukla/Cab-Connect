using BookTaxi.CustomExceptions;
using BookTaxi.Models;
using BookTaxi.Services.IServices;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookTaxi.Services
{
    public class RiderDetailsService: IRiderDetailsService
    {
        private readonly EF_DataContext _context;
        public RiderDetailsService(EF_DataContext context) 
        { 
            _context = context;
        }
        // Adding a Rider to our database
        public RiderResponseViewModel AddRider(RiderRequestViewModel riderDeatails)
        {
            // Create a new Rider entity from the ViewModel
            var rider = new Rider
            {
                Name = riderDeatails.Name,
                Email = riderDeatails.Email,
                Password = riderDeatails.Password,
                PhoneNumber = riderDeatails.PhoneNumber
            };
            if (_context.Riders.FirstOrDefault(u => u.Email.ToLower() == riderDeatails.Email.ToLower())!=null)
            {
                throw new UserAlreadyExistException();
            }
            // Add the Rider to the context and save changes to the database
            _context.Riders.Add(rider);
            _context.SaveChanges();

            // Create and return a response ViewModel with the added rider's details
            var riderResponseViewModel = new RiderResponseViewModel
            {
                Name = rider.Name,
                Email = rider.Email,
                PhoneNumber=rider.PhoneNumber
            };

            return riderResponseViewModel;
        }
    }
}
