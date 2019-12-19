import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StartPageComponent } from './account/components/start-page/start-page.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './account/services/auth.guard';
import { RegisterComponent } from './account/components/register/register.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { FileSharingComponent } from './file-sharing/file-sharing.component';

const routes: Routes = [
  {
    path:'',
    component: StartPageComponent
  },
  {
    path: 'auth-callback',
    component: AuthCallbackComponent
  },
  {
    path:'home',
    component: HomeComponent,
    //canActivate: [AuthGuard]
  },
  {
    path:'files',
    component: FileSharingComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
