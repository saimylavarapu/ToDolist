import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { AddemployeeComponent } from './addemployee/addemployee.component';
import { GetallComponent } from './getall/getall.component';
import { EditComponent } from './edit/edit.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { ViewTasksComponent } from './view-tasks/view-tasks.component';
import { ViewAlltasksComponent } from './view-alltasks/view-alltasks.component';
import { EdittasksComponent } from './edittasks/edittasks.component';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ViewTasksComponent,
    EditComponent,
    ViewAlltasksComponent,
    AddemployeeComponent,
    AddTaskComponent,
 
    GetallComponent,
    EdittasksComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxExtendedPdfViewerModule,
    
   
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'addemployee', component: AddemployeeComponent },
      { path: 'Addtask', component: AddTaskComponent },
      { path: 'getallusers', component: GetallComponent },
      { path: 'edit/:id', component: EditComponent },
      { path: 'viewalltask', component: ViewAlltasksComponent },
      { path: 'viewtask/:id', component: ViewTasksComponent },
      { path: 'edits/:id', component: EdittasksComponent }
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

