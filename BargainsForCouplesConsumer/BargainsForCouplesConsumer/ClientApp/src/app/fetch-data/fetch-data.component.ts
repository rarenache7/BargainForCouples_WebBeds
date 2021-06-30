import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BargainOffer } from '../models/bargainOffer';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  bargains: BargainOffer[];
  destinationId: number;
  numberOfNights: number;
  fullUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.fullUrl = baseUrl + "api/bargains/findbargains";
  }

  fetchBargains() {
    this.http.post<BargainOffer[]>(this.fullUrl, [this.destinationId.toString(), this.numberOfNights.toString()]).subscribe(result => {
      this.bargains = result;
    }, error => console.error(error));
  }
}
