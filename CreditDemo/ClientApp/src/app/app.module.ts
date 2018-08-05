import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AddSalesComponent } from './addSales/addSales.component';
import { DemoService } from '../shared/demoService';
import { ListSalesComponent } from './listSales/listSales.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    AddSalesComponent,
    ListSalesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: AddSalesComponent, pathMatch: 'full' },
      { path: 'add-sales', component: AddSalesComponent },
      { path: 'list-sales', component: ListSalesComponent }
   ])
  ],
  providers: [DemoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
