using SeekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PromotionEngineContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var users = new User[] {
                    new User() { UserName="unilever", Password="111",DateCreated = DateTime.Now},
                    new User() { UserName="apple", Password="111",DateCreated = DateTime.Now},
                    new User() { UserName="nike", Password="111",DateCreated = DateTime.Now},
                    new User() { UserName="ford", Password="111",DateCreated = DateTime.Now}
                };
                foreach (var user in users)
                {
                    context.Users.Add(user);
                }
                context.SaveChanges();
            }
            // Look for any ad.
            if (!context.Ads.Any())
            {
                var ads = new Ad[]
                {
                    new Ad() {AdName = "Classic Ad", AdType= AdType.Classic, Rate = 269.99m,IsEnabled =true,DateCreated = DateTime.Now},
                    new Ad() {AdName = "Standout Ad",AdType= AdType.Standout,Rate = 322.99m,IsEnabled =true,DateCreated = DateTime.Now},
                    new Ad() {AdName = "Premium Ad",AdType= AdType.Premium,Rate = 394.99m,IsEnabled =true,DateCreated = DateTime.Now}
                };
                foreach (var ad in ads)
                {
                    context.Ads.Add(ad);
                }
                context.SaveChanges();
            }
            //unilever promotion
            var promoUnilever = new Promotion()
            {
                PromoName = "UNILEVER Promo",
                EligibilityCriteria = new EligibilityCriteria()
                {
                    Conditions = new EligibilityCondition[] {
                        new EligibilityCondition() { Operand = Operand.UserId,Operator=Operator.Equals,Value="1" , Gate=Gate.AND},
                        new EligibilityCondition() { Operand = Operand.AdType,Operator=Operator.Equals,Value="0" , Gate=Gate.AND},
                        new EligibilityCondition() { Operand = Operand.Quantity,Operator=Operator.GreaterThan,Value="2" , Gate=Gate.NONE}
                    },
                    Discount = new Discount()
                    {
                        MinQuantity = 2,
                        FreeAds = 1,
                        DiscountPercentage = 33.33m
                    }
                }
            };
            var promoApple = new Promotion()
            {
                PromoName = "Apple Promo",
                EligibilityCriteria = new EligibilityCriteria()
                {
                    Conditions = new EligibilityCondition[] {
                        new EligibilityCondition() { Operand = Operand.UserId,Operator=Operator.Equals,Value="2" , Gate=Gate.AND},
                        new EligibilityCondition() { Operand = Operand.AdType,Operator=Operator.Equals,Value="1" , Gate=Gate.NONE},
                    },
                    Discount = new Discount()
                    {
                        MinQuantity = 1,
                        DiscountPercentage = 8
                    }
                }
            };
            var promoNike = new Promotion()
            {
                PromoName = "Nike Promo",
                EligibilityCriteria = new EligibilityCriteria()
                {
                    Conditions = new EligibilityCondition[] {
                        new EligibilityCondition() { Operand = Operand.UserId,Operator=Operator.Equals,Value="2" , Gate=Gate.AND},
                        new EligibilityCondition() { Operand = Operand.AdType,Operator=Operator.Equals,Value="2" , Gate=Gate.NONE},
                    },
                    Discount = new Discount()
                    {
                        MinQuantity = 4,
                        DiscountPercentage = 4
                    }
                }
            };

            if (!context.Promotions.Any())
            {
                context.Promotions.Add(promoUnilever);
                context.Promotions.Add(promoApple);
                context.Promotions.Add(promoNike);
                context.SaveChanges();
            }

        }
    }
}
