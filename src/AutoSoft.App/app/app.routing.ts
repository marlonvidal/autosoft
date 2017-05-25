import { Routes, RouterModule } from '@angular/router';

import { SecureComponent } from './layouts/index'
import { HomeComponent, SECURE_ROUTES } from './secure/index';
import { LoginComponent } from './login/index';
import { RegisterComponent } from './register/index';
import { AuthGuard } from './_guards/index';

const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    //{ path: 'register', component: RegisterComponent },
    { path: 'secure', component: SecureComponent, canActivate: [AuthGuard], children: SECURE_ROUTES },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);