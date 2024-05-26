using Assigmnent_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Controllers.TestData
{
    public class LoginControllerTestData
    {
        public static IEnumerable<object[]> InvalidLoginData()
        {
            yield return new object[] { new LoginModel { Username = "invaliduser", Password = "invalidpassword" } };
        }
    }
}
