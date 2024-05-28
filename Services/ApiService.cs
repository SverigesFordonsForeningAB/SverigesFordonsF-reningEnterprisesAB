using System.ComponentModel;
using System.Text;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SverigesFordonsFöreningEnterprisesAB.Models;

namespace SverigesFordonsFöreningEnterprisesAB.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService(IHttpClientFactory clientfactory)
        {
            _client = clientfactory.CreateClient("APIClient");
        }
        ////////////////////////////////////   [CUSTOMER]   /////////////////////////////////////////////
        // Get all Customer GetCustomerAsync();
        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                var response = await _client.GetAsync("customers");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Customer>();
                }
                var jsonstring = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(jsonstring);
                return customers;

            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }
        //Create a new Customer
        public async Task AddCustomerAsync(Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("customer", data);
            response.EnsureSuccessStatusCode();
        }
        //Update Customer
        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responde = await _client.PutAsync($"customer/{id}", data);
            responde.EnsureSuccessStatusCode();
        }
        //Delet a customer
        public async Task DeletCustomerAsync(int id)
        {
            var response = await _client.DeleteAsync($"customer/{id}");
            response.EnsureSuccessStatusCode();
        }
        //Return customer by id
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var response = await _client.GetAsync($"customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
            else
            {
                throw new InvalidOperationException($"API failed with statuscode {response.StatusCode}");
            }
        }

        ////////////////////////////////////   [CAR]   /////////////////////////////////////////////
        // Get all Cars 
        public async Task<List<Car>> GetCarAsync()
        {
            try
            {
                var responde = await _client.GetAsync("cars");
                if (!responde.IsSuccessStatusCode)
                {
                    return new List<Car>();
                }
                var jsonString = await responde.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<List<Car>>(jsonString);
                return car;
            }
            catch (Exception ex)
            {
                return new List<Car>();
            }
        }
        //Create a new Car
        public async Task AddCarAsync(Car car)
        {
            var json = JsonConvert.SerializeObject(car);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("car", data);
            response.EnsureSuccessStatusCode();
        }
        // Update Car
        public async Task UpdateCarAsync(int id, Car car)
        {
            var json = JsonConvert.SerializeObject(car);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"car/{id}", data);
            response.EnsureSuccessStatusCode();
        }
        // Delet an Car
        public async Task DeleteCarAsync(int id)
        {
            var response = await _client.DeleteAsync($"car/{id}");
            response.EnsureSuccessStatusCode();
        }
        // Returns an car by id
        public async Task<Car> GetCarByIdAsync(int id)
        {
            var response = await _client.GetAsync($"car/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Car>();
            }
            else
            {
                throw new InvalidOperationException($"API failed with statuscode {response.StatusCode}");
            }
        }

        ////////////////////////////////////   [Motorcycle]   /////////////////////////////////////////////
        // Get all Motorcycle
        public async Task<List<Motorcycle>> GetMotorcycleAsync()
        {
            try
            {
                var response = await _client.GetAsync("motorcycle");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Motorcycle>();
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var motorcycles = JsonConvert.DeserializeObject<List<Motorcycle>>(jsonString);
                return motorcycles;
            }
            catch (Exception ex)
            {
                return new List<Motorcycle>();
            }
        }

        //Create a new motorcycle
        public async Task AddMotorcycleAsync(Motorcycle motorcycle)
        {
            var json = JsonConvert.SerializeObject(motorcycle);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("motorcycle", data);
            response.EnsureSuccessStatusCode();
        }
        //Update motorcycle
        public async Task UpdateMotorcycleAsync(int id, Motorcycle motorcycle)
        {
            var json = JsonConvert.SerializeObject(motorcycle);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responde = await _client.PutAsync($"motorcycle/{id}", data);
            responde.EnsureSuccessStatusCode();
        }
        // Delet an Motorcycle
        public async Task DeleteMotorcycleAsync(int id)
        {
            var response = await _client.DeleteAsync($"motorcycle/{id}");
            response.EnsureSuccessStatusCode();
        }
        // Returns an car by id
        public async Task<Motorcycle> GetMotorcycleByIdAsync(int id)
        {
            var response = await _client.GetAsync($"motorcycle/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Motorcycle>();
            }
            else
            {
                throw new InvalidOperationException($"API failed with statuscode {response.StatusCode}");
            }
        }


        ////////////////////////////////////   [Order]   /////////////////////////////////////////////
        // Get all Order
        public async Task<List<Order>> GetOrderAsync()
        {
            try
            {
                var response = await _client.GetAsync("orders");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Order>();
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<Order>>(jsonString);
                return orders;
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        //Create a new Order
        public async Task AddOrderAsync(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("order", data);
            response.EnsureSuccessStatusCode();
        }
        //Update Order
        public async Task UpdateOrderAsync(int id, Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responde = await _client.PutAsync($"order/{id}", data);
            responde.EnsureSuccessStatusCode();
        }
        // Delet an Order
        public async Task DeleteOrderAsync(int id)
        {
            var response = await _client.DeleteAsync($"order/{id}");
            response.EnsureSuccessStatusCode();
        }
        // Returns an Order by id
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var response = await _client.GetAsync($"order/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Order>();
            }
            else
            {
                throw new InvalidOperationException($"API failed with statuscode {response.StatusCode}");
            }
        }

    }
}