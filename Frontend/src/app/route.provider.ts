import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/dashboard',
        name: '::Menu:Dashboard',
        iconClass: 'fas fa-chart-line',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'EmpManagement.Dashboard.Host || AbpAccount.SettingManagement',
      },
      {
        path: '/emp-management',
        name: '::EmpManagement',
        iconClass: 'fas fa-user',
        order: 101,
        layout: eLayoutType.application,
      },
     
      {
        path: '/departments',
        name: '::Departments',
        parentName: '::EmpManagement',
        layout: eLayoutType.application
      },
      {
        path: '/employees',
        name: '::Employees',
        parentName: '::EmpManagement',
        layout: eLayoutType.application,
        requiredPolicy: 'EmpManagement.Employees',
      }
    ]);
  };
}
