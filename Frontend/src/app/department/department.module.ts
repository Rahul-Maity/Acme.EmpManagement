import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentComponent } from './department.component';
import { SharedModule } from '../shared/shared.module';
import { PageModule } from '@abp/ng.components/page';


@NgModule({
  declarations: [
    DepartmentComponent
  ],
  imports: [
    DepartmentRoutingModule,
    SharedModule,
    
    PageModule
  ]
})
export class DepartmentModule { }
