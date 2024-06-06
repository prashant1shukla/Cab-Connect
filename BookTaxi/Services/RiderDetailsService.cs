using BookTaxi.CustomExceptions;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

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
        public RiderResponse AddRider(RiderRequest riderDeatails)
        {
            // Create a new Rider entity from the ViewModel
            var rider = new User
            {
                UserId= Guid.NewGuid(),
                Name = riderDeatails.Name,
                Email = riderDeatails.Email,
                Password = riderDeatails.Password,
                PhoneNumber = riderDeatails.PhoneNumber,
                UserRole = UserRole.Rider,
            };
            if (_context.Users.FirstOrDefault(u => u.Email.ToLower() == riderDeatails.Email.ToLower()) != null)
            {
                throw new UserAlreadyExistException();
            }

            // Add the Rider to the context and save changes to the database
            _context.Users.Add(rider);
            _context.SaveChanges();

            // Create and return a response ViewModel with the added rider's details
            var riderResponseViewModel = new RiderResponse
            {
                UserId = rider.UserId,
                Name = rider.Name,
                Email = rider.Email,
                PhoneNumber = rider.PhoneNumber,
                UserRole = rider.UserRole.ToString()
            };

            return riderResponseViewModel;
        }
    }
}
