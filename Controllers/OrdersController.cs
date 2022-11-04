using Microsoft.AspNetCore.Mvc;
using OnlineTickets.Data.Cart;
using OnlineTickets.Data.Services;
using OnlineTickets.Data.ViewModels;

namespace OnlineTickets.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IMoviesService _movieservice;
        private readonly ShoppingCart _shoppingcart;
        private readonly IOrdersService _orderService;
        public OrdersController(IMoviesService movieservice, ShoppingCart shoppingcart, IOrdersService orderService)
        {
            _movieservice = movieservice;
            _shoppingcart = shoppingcart;
            _orderService = orderService;
            _orderService = orderService;
        }


        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _orderService.GetOrderByUserIdAsync(userId);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            _shoppingcart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingcart,
                ShoppingCartTotal = _shoppingcart.GetShoppingCartTotal()

            };

            return View(response);
        }


        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _movieservice.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingcart.AddItemToCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }



        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieservice.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingcart.RemoveItemFromCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";


            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingcart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
