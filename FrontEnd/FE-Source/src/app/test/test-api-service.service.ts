import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestApiServiceService {

  constructor(private _httpClient: HttpClient) {
  }

  tesApi() {
    this._httpClient.get('test').subscribe(res => {
      console.log("Result test = ", res);
    })
  }
}
