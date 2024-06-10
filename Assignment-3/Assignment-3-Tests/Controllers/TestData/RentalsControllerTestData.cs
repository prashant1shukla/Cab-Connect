using Assignment_3.Controllers;
using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Controllers.TestData
{
    public static class RentalsControllerTestData
    {
        public static IEnumerable<object[]> RentMovieToCustomerData()
        {
            //Positive test case
            yield return new object[] { 1, 1, true };
            //Negative test case
            yield return new object[] { 1, 2, false };
        }

        public static IEnumerable<object[]> RentMovieToCustomerByTitleAndUsernameData()
        {
            // Positive test case
            yield return new object[] { "Test Movie", "Test User", true };
            // Negative test case
            yield return new object[] { "Test Movie", null, false };
        }
    }
}
