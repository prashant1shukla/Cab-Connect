using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services.IServices
{
    public interface IDriverDetailsService
    {
        DriverResponse AddDriver(DriverRequest driverDetails);
    }
}
