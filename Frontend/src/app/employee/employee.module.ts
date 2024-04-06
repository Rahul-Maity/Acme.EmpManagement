import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { SharedModule } from '../shared/shared.module';
import { PageModule } from '@abp/ng.components/page';


@NgModule({
  declarations: [
    EmployeeComponent
  ],
  imports: [
    SharedModule,
    PageModule,

    EmployeeRoutingModule
  ]
})
export class EmployeeModule { }
