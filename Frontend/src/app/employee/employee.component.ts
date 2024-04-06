
import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { EmployeeService, EmployeeDto } from '@proxy/employees';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartmentDto, DepartmentService } from '@proxy/departments';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.scss',
  providers:[ListService],
})
export class EmployeeComponent implements OnInit{
  constructor(public readonly list: ListService,
    private employeeService: EmployeeService,
    private departmentService:DepartmentService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService 
  ) { }
  
    selectedEmployee = {} as EmployeeDto; // declare selectedBook

  employee = { items: [], totalCount: 0 } as PagedResultDto<EmployeeDto>;
  department = { items: [], totalCount: 0 } as PagedResultDto<DepartmentDto>;
  form: FormGroup; 
  isModalOpen = false; // add this line

  ngOnInit(): void {
    const employeeStreamCreator = (query) => this.employeeService.getList(query);
    const departmentStreamCreator = (query) => this.departmentService.getList(query);

    this.list.hookToQuery(employeeStreamCreator).subscribe((response) => {
      this.employee= response;
    });

    this.list.hookToQuery(departmentStreamCreator).subscribe((response) => {
      this.department= response;
      console.log(this.department);
     
    });

   
  }





    // add new method
  createEmployee() {
    this.selectedEmployee = {} as EmployeeDto;
    this.buildForm();
      this.isModalOpen = true;
  }
  

    // Add editBook method
    editEmployee(id: string) {
      this.employeeService.get(id).subscribe((employee) => {
        this.selectedEmployee = employee;
        this.buildForm();
        this.isModalOpen = true;
      });
  }
  

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.employeeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }



  buildForm() {
    this.form = this.fb.group({
      FullName: ['', Validators.required],
      Position: [null, Validators.required],
      age: [null, Validators.required],
      DepartmentId: [null, Validators.required],
    });
  }


  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedEmployee.id
    ? this.employeeService.update(this.selectedEmployee.id, this.form.value)
      : this.employeeService.create(this.form.value);
    
      request.subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });


  }

}
