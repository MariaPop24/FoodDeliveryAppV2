import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  public url = 'https://localhost:44301/api/Customers/Get-select';

  constructor(
    public http: HttpClient
  ) { }

  public getAllCustomers(): Observable<any> {
    return this.http.get(`${this.url}`);
  }
}
