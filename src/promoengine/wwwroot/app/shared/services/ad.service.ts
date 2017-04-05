import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, RequestMethod, Headers } from '@angular/http';
import { Ad } from '../models/ad';


@Injectable()
export class AdService {

    constructor(private http: Http) { }

    getAds() {
        return this.http.get('api/ads')
            .map(response => <Ad[]>response.json());
    }

    addtoCart(ad: Ad) {
        var requestoptions = new RequestOptions({
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        });
        return this.http.post('api/cart', JSON.stringify(ad), requestoptions).map(response => response.json());
    }
}