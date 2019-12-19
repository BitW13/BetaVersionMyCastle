import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
    { 
        path: 'register', 
        component: RegisterComponent
    }    
];
    
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: []
})
export class AccountRoutingModule { }