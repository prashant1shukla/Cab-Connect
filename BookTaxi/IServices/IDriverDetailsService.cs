using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.IServices
{
    public interface IDriverDetailsService
    {
        DriverResponse AddDriver(DriverRequest driverDetails);
    }
}
