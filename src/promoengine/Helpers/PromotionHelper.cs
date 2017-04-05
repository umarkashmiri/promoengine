using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SeekWeb.Data;
using SeekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promoengine.Helpers
{
    public class PromotionHelper
    {
        private PromotionEngineContext _context;
        public PromotionHelper(PromotionEngineContext context) { _context = context; }

        private List<Promotion> GetAllPromotions()
        {
            try
            {
                return this._context.Promotions.Include(p => p.EligibilityCriteria).ThenInclude(p => p.Conditions).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ApplyPromotion(Cart cart)
        {
            if (cart != null && cart.CartItems != null)
            {
                foreach (var promotion in GetAllPromotions())
                {
                    if (promotion != null)
                    {
                        if (promotion.EligibilityCriteria != null &&
                            promotion.EligibilityCriteria.Conditions != null &&
                            promotion.EligibilityCriteria.Conditions.Count > 0)
                        {
                            foreach (var item in cart.CartItems)
                            {
                                bool allMatched = false;
                                int conditionsMatched = 0;
                                foreach (var condition in promotion.EligibilityCriteria.Conditions)
                                {
                                    switch (condition.Operand)
                                    {
                                        case Operand.Quantity:
                                            if (item.Quantity >= Convert.ToInt32(condition.Value))
                                            {
                                                conditionsMatched++;
                                            }
                                            break;
                                        case Operand.AdType:
                                            if (condition.Value == ((int)item.Ad.AdType).ToString())
                                            {
                                                conditionsMatched++;
                                            }
                                            break;
                                        case Operand.UserId:
                                            if (condition.Value.Equals(cart.User.UserId.ToString()))
                                            {
                                                conditionsMatched++;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    if (conditionsMatched == promotion.EligibilityCriteria.Conditions.Count)
                                    {
                                        allMatched = true;
                                    }
                                }
                                if (allMatched)
                                {
                                    _context.Entry(promotion.EligibilityCriteria).Reference(p => p.Discount).Load();
                                    item.Discount = item.Rate - (item.Rate * promotion.EligibilityCriteria.Discount.DiscountPercentage / 100);
                                }
                            }
                            try
                            {
                              int test =  _context.SaveChanges(true);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
