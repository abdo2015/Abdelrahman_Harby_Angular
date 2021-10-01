import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent } from './details/details.component';
import { HomeComponent } from './home/home.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
    {path:'', component: HomeComponent},
    {path:'home', component: HomeComponent},
    {path:'details/:id', component: DetailsComponent},
    {path:'add', component: UploadComponent},



  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
