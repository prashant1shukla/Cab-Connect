using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services
{
    public class RequestRideService
    {
        private readonly EF_DataContext _context;
        public RequestRideService(EF_DataContext context)
        {
            _context = context;
        }
        //public RequestRideResponseViewModel RequestRide(RequestRideRequestViewModel rideDetails)
       // {
            //checking driver's availability
            //var driver = _context.Drivers.FirstOrDefault(u=>u.);
            
        //}
    }
}
