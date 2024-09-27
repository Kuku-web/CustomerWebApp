using CustomerWebApp.Models;

namespace CustomerWebApp.Service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerAsync(int id);
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<bool?> DeleteCustomerAsync(int id);
        Task<bool?> UpdateCustomerAsync(int id, Customer customer);
    }
}
