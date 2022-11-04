using Microsoft.AspNetCore.Mvc;
using OnlineTickets.Data.Cart;

namespace OnlineTickets.Data.ViewComponents
{
    public class ShoppingCartSummery : ViewComponent
    {

        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummery(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}

