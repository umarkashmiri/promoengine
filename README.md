# promoengine

In this example,
We have three types of Ad products 
1- classic
2- standard
3 - premium

and 4 users for whom we need to setup promotional discounts.

Promotions:

To create configureable promtions, we need to define set of rules, which can be applied on shopping cart when user tries to purchase some products.
Every promotion will have some certian set of conditions (we can call it criteria) which we can evaluate at the time of purchase.
e.g if user tries to buy 2 classic ads and we want to give certain type of user one ad free, In promotion we will define those rules.

So here is the schema,
DB schema:

![Alt text](https://raw.githubusercontent.com/umarkashmiri/promoengine/master/schema.PNG "Optional Title")

e.g UNILEVER

- Gets a for 3 for 2 deal on Classic Ads

We can define number of conditions for this in EligibilityConditions table,
1. user should be UNILEVER;
2. AdType should be classic
3. quantity should be 3 atleast.

Once these conditions met, we need to perform some action i.e apply discounts; For this we have discounts table.
if condition is met pick up relevant discount and apply on each item of shoppingcart.
For above example, we can provide discount of 33.33% to customer, and user will get one item free.

Cart:

Once user add one item to shoppingcart, cart item is being evaluated for promotions. If any of the promotion EligibilityCriteria meet, we will pickup discount
and apply to shopping cart items.

We can make it more configureable by adding discount types. but for this example, i have created several conditions to support all the given scenarios.

Ad rate will remain constant, while cartitem rate will be calculated after applying discounts.
