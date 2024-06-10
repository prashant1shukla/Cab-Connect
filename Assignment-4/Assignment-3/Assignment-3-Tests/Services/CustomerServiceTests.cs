using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Services
{
    public class CustomerServiceTests
    {
        [Fact]
        public void AddCustomer_PositiveTest()
        {
            // Arrange
            var customerRequestDTO = new CustomerRequestDTO
            {
                Username = "TestUser"
            };

            var mockDbSet = new Mock<DbSet<Customer>>();
            var customer = new Customer
            {
                Username = customerRequestDTO.Username
            };
            mockDbSet.Setup(m => m.Add(It.IsAny<Customer>())).Callback<Customer>(c => customer = c);

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Customers).Returns(mockDbSet.Object);

            var customerService = new CustomerService(mockContext.Object);

            // Act
            var result = customerService.AddCustomer(customerRequestDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Username, result.Username);
        }

        [Fact]
        public void AddCustomer_NegativeTest()
        {
            // Arrange
            var customerRequestDTO = new CustomerRequestDTO
            {
                Username = "TestUser"
            };

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Customers.Add(It.IsAny<Customer>())).Throws(new Exception("Failed to add customer"));

            var customerService = new CustomerService(mockContext.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => customerService.AddCustomer(customerRequestDTO));
        }


        [Fact]
        public void GetCustomersForMovie_PositiveTest()
        {
            // Arrange
            int movieId = 1;

            // Create mock data for customers
            var customersData = new List<Customer>
    {
        new Customer { Id = 1, Username = "User1", Rentals = new List<Rental> { new Rental { MovieId = movieId } } },
        new Customer { Id = 2, Username = "User2", Rentals = new List<Rental>() },
        new Customer { Id = 3, Username = "User3", Rentals = new List<Rental> { new Rental { MovieId = movieId } } }
    }.AsQueryable();

            // Setup mock DbSet for customers
            var mockDbSet = new Mock<DbSet<Customer>>();
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customersData.Provider);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customersData.Expression);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customersData.ElementType);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customersData.GetEnumerator());

            // Setup mock context with the mock DbSet
            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Customers).Returns(mockDbSet.Object);

            var customerService = new CustomerService(mockContext.Object);

            // Act
            var result = customerService.GetCustomersForMovie(movieId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count); // There are two customers associated with the movie
        }

        // Negative test case for GetCustomersForMovie method
        [Fact]
        public void GetCustomersForMovie_NegativeTest()
        {
            // Arrange
            int movieId = 1;

            var customers = new List<Customer>().AsQueryable(); // Empty customer list

            var mockDbSet = new Mock<DbSet<Customer>>();
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Customers).Returns(mockDbSet.Object);

            var customerService = new CustomerService(mockContext.Object);

            // Act
            var result = customerService.GetCustomersForMovie(movieId);

            // Assert
            Assert.Empty(result); // Assert that no customers are associated with the movie
        }
    
    // Additional test cases can be added similarly for other methods in CustomerService
}
}
