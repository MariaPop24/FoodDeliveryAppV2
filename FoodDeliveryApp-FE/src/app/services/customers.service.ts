import { HttpClient, HttpContext, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/interfaces/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  public url = 'https://localhost:44301/api/Customers';

  constructor(
    public http: HttpClient
  ) { }

  public getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.url}/Get-select`);
  }

  // public deleteCustomer(customer: any): Observable<any> {

  //   return this.http.delete<any>(`${this.url}/Delete/${customer.id}`, customer);
  // }

  public deleteCustomer(id: any): Observable<any> {

    return this.http.delete<any>(`${this.url}/Delete/${id}`);
  }
}
