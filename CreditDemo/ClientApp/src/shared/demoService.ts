import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { SalesModel } from './sales.model';


@Injectable()
export class DemoService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }


  saveSales(sales: SalesModel) {

    return this._http.post(this.myAppUrl + "api/Sales", sales);
  }

  getSales(): Observable<SalesModel[]> {

    return this._http.get<SalesModel[]>(this.myAppUrl + "api/Sales");

  }


  getSaleId(): Observable<number> {

    return this._http.get<number>(this.myAppUrl + "api/Sales/SaleId");

  }


}
