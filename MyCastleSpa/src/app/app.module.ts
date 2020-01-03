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
import { FileItemComponent } from './file-sharing/file-item/file-item.component';
import { FileCategoryItemComponent } from './file-sharing/file-category-item/file-category-item.component';
import { FileAccessItemComponent } from './file-sharing/file-access-item/file-access-item.component';
import { TaskComponent } from './task/task.component';
import { TaskItemComponent } from './task/task-item/task-item.component';
import { TaskCategoryComponent } from './task/task-category/task-category.component';
import { TaskSeverityComponent } from './task/task-severity/task-severity.component';

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
    DownloadComponent,
    FileItemComponent,
    FileCategoryItemComponent,
    FileAccessItemComponent,
    //TaskComponent,
    //TaskItemComponent,
    //TaskCategoryComponent,
    //TaskSeverityComponent
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
