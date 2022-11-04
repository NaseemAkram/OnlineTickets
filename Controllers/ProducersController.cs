using Microsoft.AspNetCore.Mvc;
using OnlineTickets.Data.Services;
using OnlineTickets.Models;

namespace OnlineTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allproducers = await _service.GetAllAsync();
            return View(allproducers);
        }


        //Producers/Details/id

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producersdetails = await _service.GetByIdAsync(id);
            if (producersdetails == null)
            {
                return View("NotFound");
            }
            return View(producersdetails);
        }


        //create action result
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        //Producers/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);

        }



        [HttpGet]
        //Producers/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
