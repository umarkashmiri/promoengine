using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using promoengine.Helpers;
using SeekWeb.Data;
using SeekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promoengine.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CartController : Controller
    {
        private readonly PromotionEngineContext _context;
        public CartController(PromotionEngineContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces(typeof(string[]))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Cart.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ad ad)
        {
            //setting it for uniliver for now for test
            int userid = 1;
            User user = null;
            //if (HttpContext.Items["uid"] != null)
            {
                //userid = Convert.ToInt32(HttpContext.Items["uid"]);
                user = _context.Users.Where(u => u.UserId == userid).FirstOrDefault();
            }
            if (user == null)
            {
                return NotFound(new { error = "user not found", data = "" });
            }
            var userCart = await _context.Cart.Where(c => c.User.UserId == userid).ToListAsync();
            //existing cart
            Cart cart = null;
            if (userCart == null || userCart.Count == 0)
            {
                cart = new Cart() { User = user };
            }
            else
            {
                cart = userCart.FirstOrDefault();
            }
            if (cart.CartItems == null)
            {
                cart.CartItems = new List<CartItem>();
            }
            // if ther are items in the cart, we need to check existing to increase quantity
            bool isAlreadyIncart = false;
            foreach (var item in cart.CartItems)
            {
                if (item.Ad.AdId == ad.AdId)
                {
                    item.Quantity++;
                    item.Rate = (item.Ad.Rate * item.Quantity);
                    isAlreadyIncart = true;
                }
            }
            if (!isAlreadyIncart)
            {
                cart.CartItems.Add(new CartItem() { Ad = ad, Quantity = 1, Rate = ad.Rate });
            }

            var promoHelper = new PromotionHelper(_context);
            promoHelper.ApplyPromotion(cart);

            return Ok(new { error = "", data = cart });
        }

    }
}
