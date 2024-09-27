using CustomerWebApp.Models;
using CustomerWebApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApp.Controllers
{
    public class CustomerController(ICustomerService customerService) : Controller
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<IActionResult> Index()
        {
            return View(await _customerService.GetAllCustomersAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
               var result = await _customerService.CreateCustomerAsync(customer);
                if (!result)
                {
                    return BadRequest("Customer already exits");
                }

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _customerService.UpdateCustomerAsync(id,customer);
                if (result == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteId(int id)
        {
            var customer = await _customerService.DeleteCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
