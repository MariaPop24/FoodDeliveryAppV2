import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Customer } from 'src/app/interfaces/customer';
import { User } from 'src/app/interfaces/user';
import { CustomersService } from 'src/app/services/customers.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit, OnDestroy {

  public subscription!: Subscription;
  public loggedUser!: User;
  public parentMessage = 'message from parent';
  public customers: Customer[] = [];
  public displayedColumns = ['id', 'firstName', 'lastName', 'mail', 'phoneNumber', 'delete']

  constructor(
    private router: Router,
    private dataService: DataService,
    private customersService: CustomersService
  ) { }

  ngOnInit() {
    this.subscription = this.dataService.currentUser.subscribe((user: User) => this.loggedUser = user);
    this.customersService.getAllCustomers().subscribe(
      (result: Customer[]) => {
        console.log(result);
        this.customers = result;
      },
      (error) => {
        console.log(error);
      }
    )
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role', 'Anonim');
    this.router.navigate(['/login']);
  }

  public receiveMessage(event: any): void {
    console.log(event);
  }

  public deleteCustomer(customer: any): void {
    this.customersService.deleteCustomer(customer).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    )
  }
}
