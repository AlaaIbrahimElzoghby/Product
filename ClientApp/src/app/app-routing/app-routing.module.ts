import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from '../Components/products/products.component';
import { ProductAddEditComponent } from '../Components/product-add-edit/product-add-edit.component';

const routes: Routes = [
  { path: '', component: ProductsComponent, pathMatch: 'full' },
  { path: 'add', component: ProductAddEditComponent },
  { path: 'product/edit/:id', component: ProductAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
