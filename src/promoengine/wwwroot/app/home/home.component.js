"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var ad_service_1 = require("../shared/services/ad.service");
var HomeComponent = (function () {
    function HomeComponent(adService) {
        this.adService = adService;
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.adService.getAds()
            .subscribe(function (ads) { return _this.Ads = ads; });
    };
    HomeComponent.prototype.onBuyNowClick = function (ad) {
        var _this = this;
        console.log(ad);
        this.adService.addtoCart(ad).subscribe(function (res) {
            console.log(res);
            _this.cart = res.data;
        });
    };
    return HomeComponent;
}());
HomeComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'home.component.html'
    }),
    __metadata("design:paramtypes", [ad_service_1.AdService])
], HomeComponent);
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map