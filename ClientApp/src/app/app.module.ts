import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { ProductService } from './product.service';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ProductAddEditComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
