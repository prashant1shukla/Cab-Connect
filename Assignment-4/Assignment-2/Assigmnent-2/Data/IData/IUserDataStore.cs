using Assigmnent_2.Models;

namespace Assigmnent_2.Data.IData
{
    public interface IUserDataStore
    {
        List<UserModel> Users { get; }
    }
}
