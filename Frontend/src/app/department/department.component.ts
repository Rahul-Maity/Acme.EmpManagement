import { ListService, PagedResultDto } from '@abp/ng.core';
import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { DepartmentService, DepartmentDto } from '@proxy/departments';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrl: './department.component.scss',
  providers:[ListService],
})
export class DepartmentComponent implements OnInit{

  form: FormGroup;
  selectedDepartment = {} as DepartmentDto; 


  department = { items: [], totalCount: 0 } as PagedResultDto<DepartmentDto>;
  isModalOpen = false;
  constructor(public readonly list: ListService, private departmentService: DepartmentService, private fb: FormBuilder,
  private confirmation:ConfirmationService) { }



  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.departmentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }



  ngOnInit(): void {
    const departmentStreamCreator = (query) => this.departmentService.getList(query);
    this.list.hookToQuery(departmentStreamCreator).subscribe((response) => {
      this.department = response;
      // console.log(this.department);
    });

  }
  createDepartment() {

    this.selectedDepartment = {} as DepartmentDto; 

    this.buildForm();
    this.isModalOpen = true;
  }

  // Add editBook method
  editDepartment(id: string) {
    this.departmentService.get(id).subscribe((department) => {
      this.selectedDepartment = department;
      this.buildForm();
      this.isModalOpen = true;
    });
  }


   // add buildForm method
   buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],

    });
  }
//add save method
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedDepartment.id
    ? this.departmentService.update(this.selectedDepartment.id, this.form.value)
    : this.departmentService.create(this.form.value);

    // this.departmentService.create(this.form.value).subscribe(() => {
    //   this.isModalOpen = false;
    //   this.form.reset();
    //   this.list.get();
    // });

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  
  }
  
}
