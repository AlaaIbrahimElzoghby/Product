import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/Product';

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
    }
  }
