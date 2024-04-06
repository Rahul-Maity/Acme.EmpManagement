import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'EmpManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44343/',
    redirectUri: baseUrl,
    clientId: 'EmpManagement_App',
    responseType: 'code',
    scope: 'offline_access EmpManagement',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44343',
      rootNamespace: 'Acme.EmpManagement',
    },
  },
} as Environment;
