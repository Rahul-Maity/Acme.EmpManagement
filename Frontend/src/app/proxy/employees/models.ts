import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateEmployeeDto {
  fullName: string;
  position: string;
  age: number;
  departmentId: string;
}

export interface EmployeeDto extends AuditedEntityDto<string> {
  fullName?: string;
  position?: string;
  age: number;
  departmentId?: string;
}
