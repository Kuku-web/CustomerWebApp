using CustomerWebApp.Models;


namespace CustomerWebApp.Service
{
    public class CustomerService : ICustomerService
    {
        // this should be fetched from database have it owns class
        private static readonly List<Customer> customers = new List<Customer>()
        {
            new Customer{Id= 1,FirstName="John",LastName= "Mattis", Email= "John.Mattis@customer.com", TelephoneNumber="12346"},
            new Customer{Id= 2,FirstName="David",LastName= "Mick", Email= "David.Mick@customer.com", TelephoneNumber="7654"},
            new Customer{Id= 3,FirstName="Ella",LastName= "John", Email= "Ella.John@customer.com", TelephoneNumber="3457"},
            new Customer{Id= 4,FirstName="Smith",LastName= "Sam", Email= "Smith.Sam@customer.com", TelephoneNumber="9810"},
        };
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            await Task.Delay(1000);
            return customers;
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            await Task.Delay(100);
            return customers.FirstOrDefault(c => c.Id == id);
        }
        public async Task<bool?> UpdateCustomerAsync(int id, Customer customer)
        {
           
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
                return null;

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.TelephoneNumber = customer.TelephoneNumber;
            await Task.Delay(100);
            return true;
        }

        public async Task<bool?> DeleteCustomerAsync(int id)
        {
           
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return null;

            customers.Remove(customer);
            await Task.Delay(100);
            return true;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            var customerExist = customers.FirstOrDefault(c => c.FirstName == customer.FirstName && c.Email == customer.Email);
            if(customerExist is not null)
            {
                return false;
            }
            
            customer.Id = customers.Max(c => c.Id) + 1;
            customers.Add(customer);
            await Task.Delay(100);
            return true;
        }
    }
}
