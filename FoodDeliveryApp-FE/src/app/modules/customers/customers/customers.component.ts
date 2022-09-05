import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CustomersService } from 'src/app/services/customers.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit, OnDestroy {

  public subscription!: Subscription;
  public loggedUser!: { username: string; password: string; };
  public parentMessage = 'message from parent';
  public customers = [];
  public displayedColumns = ['id', 'firstName', 'lastName']

  constructor(
    private router: Router,
    private dataService: DataService,
    private customersService: CustomersService
  ) { }

  ngOnInit() {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.customersService.getAllCustomers().subscribe(
      (result) => {
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
}
