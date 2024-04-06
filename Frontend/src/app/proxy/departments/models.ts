import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateDepartmentDto {
  name: string;
}

export interface DepartmentDto extends AuditedEntityDto<string> {
  name?: string;
}
