import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './account/services/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './material.module';
import { HomeComponent } from './home/home.component';
import { HomeService } from './home/services/home.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './account/services/auth.guard';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { ConfigService } from './configService';
import { InterceptorService } from './account/services/interceptor.service';
import { AccountModule } from './account/account.module';
import { BoardItemComponent } from './home/board-item/board-item.component';
import { BoardFormComponent } from './home/board-form/board-form.component';
import { AccountComponent } from './navbar/account/account.component';
import { AccountService } from './navbar/services/account.service';
import { FileSharingComponent } from './file-sharing/file-sharing.component';
import { UploadComponent } from './file-sharing/upload/upload.component';
import { DownloadComponent } from './file-sharing/download/download.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    AuthCallbackComponent,
    BoardItemComponent,
    BoardFormComponent,
    AccountComponent,
    FileSharingComponent,
    UploadComponent,
    DownloadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    AccountModule
  ],
  providers: 
  [
    AuthService, 
    ConfigService, 
    //AuthGuard, 
    HomeService,
    // { 
    //   provide: HTTP_INTERCEPTORS, 
    //   useClass: InterceptorService, 
    //   multi: true 
    // },
    AccountService
  ],
  entryComponents:[
    BoardFormComponent,
    AccountComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
