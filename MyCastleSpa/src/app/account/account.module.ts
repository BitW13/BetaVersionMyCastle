import { StartPageComponent } from './components/start-page/start-page.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountRoutingModule } from './account-routing.module';
import { MaterialModule } from '../material.module';

@NgModule({
    declarations: [
        StartPageComponent,
        RegisterComponent
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        AccountRoutingModule,
        MaterialModule
    ],
    providers: [
        AuthService
    ],
    bootstrap: []
  })
  export class AccountModule { }