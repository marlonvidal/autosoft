import { Routes  } from '@angular/router';
import { HomeComponent, ClienteComponent } from './index';
import { SecureFooterComponent, SecureNavBarComponent, SecureHeaderComponent } from "../layouts/index";

export const SECURE_ROUTES: Routes = [    
    { path: 'home', component: HomeComponent, pathMatch: 'full' },
    { path: 'clientes', component: ClienteComponent },
    { path: '', component: SecureFooterComponent, outlet: 'footer' },
    { path: '', component: SecureHeaderComponent, outlet: 'header' },
    { path: '', component: SecureNavBarComponent, outlet: 'navbar' }
]