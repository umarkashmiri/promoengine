import { Component, OnInit } from '@angular/core';

import { AdService } from '../shared/services/ad.service';
import { Ad } from '../shared/models/ad';
import { Cart } from '../shared/models/cart';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})
export class HomeComponent implements OnInit {
    cart: Cart;
    Ads: Ad[];

    constructor(private adService: AdService) { }

    ngOnInit() {
        this.adService.getAds()
            .subscribe(ads => this.Ads = ads);
    }

    onBuyNowClick(ad: Ad) {
        console.log(ad);

        this.adService.addtoCart(ad).subscribe((res: any) => {
            console.log(res);
            this.cart = res.data;
        });
    }
}