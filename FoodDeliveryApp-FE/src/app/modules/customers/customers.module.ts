import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { CustomersComponent } from './customers/customers.component';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { ChildComponent } from './child/child.component';


@NgModule({
  declarations: [
    CustomersComponent,
    ChildComponent
  ],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    MaterialModule,
  ]
})
export class CustomersModule { }
