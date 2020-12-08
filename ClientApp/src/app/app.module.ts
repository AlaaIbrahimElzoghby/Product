import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing/app-routing.module';

import { ProductService } from './Services/product.service';

import { AppComponent } from './app.component';
import { ProductsComponent } from './Components/products/products.component';
import { ProductAddEditComponent } from './Components/product-add-edit/product-add-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ProductAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
