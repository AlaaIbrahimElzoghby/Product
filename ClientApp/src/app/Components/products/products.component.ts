import { Component,ViewChild, OnInit,Output, EventEmitter, Input, ElementRef } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/Product';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { HttpEventType } from '@angular/common/http'; 



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})

  export class ProductsComponent implements OnInit {
    Products$: Observable<Product[]>;
  
    constructor(private ProductService: ProductService) {
    }
  
    ngOnInit() {
      this.loadProducts();
    }
  
    loadProducts() {
      this.Products$ = this.ProductService.getProducts();
    }
   

    delete(productId) {
      const ans = confirm('Do you want to delete product with id: ' + productId);
      if (ans) {
        this.ProductService.deleteProduct(productId).subscribe((data) => {
          this.loadProducts();
        });
      }
    };

    public upload(event) {
      debugger;
      if (event.target.files && event.target.files.length > 0) {
        const file = event.target.files[0];
        this.ProductService.uploadFile(file).subscribe(
          data => {
            this.loadProducts();
          });
      }
    }
    
  }
