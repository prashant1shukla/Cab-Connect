using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Controllers.TestData
{
    public class UserControllerTestData
    {
        public static IEnumerable<object[]> GetUserData()
        {
            yield return new object[] { "testuser", true };
            yield return new object[] { "nonexistinguser", false };
        }
    }
}
