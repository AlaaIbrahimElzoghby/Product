import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../src/environments/environment';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  myAppUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.myAppUrl + "Product/GetAllProducts")
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(this.myAppUrl + "Product/GetProductById?productId=" + productId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

  saveProduct(product): Observable<Product> {
      return this.http.post<Product>(this.myAppUrl + "Product/Post/", JSON.stringify(product), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateProduct(Product): Observable<Product> {
      return this.http.put<Product>(this.myAppUrl + "Product/Put/", JSON.stringify(Product), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteProduct(productId: number): Observable<Product> {
      return this.http.delete<Product>(this.myAppUrl + "Product/Delete?productId=" + productId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
