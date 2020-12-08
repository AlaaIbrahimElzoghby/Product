import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/Product';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.css']
})

export class ProductAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  id: number;
  name: string;
  price: string;
  photoName: string;
  selectedFile: File
  errorMessage: any;
  existingProduct: Product;

  constructor(private blogPostService: ProductService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.name = 'name';
    this.price = "price";
    if (this.avRoute.snapshot.params[idParam]) {
      this.id = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        id: 0,
        name: ['', [Validators.required]],
        price: ['', [Validators.required]]
      }
    )
  }

  ngOnInit() {

    if (this.id > 0) {
      this.actionType = 'Edit';
      this.blogPostService.getProduct(this.id)
        .subscribe(data => (
          this.existingProduct = data,
          this.form.controls[this.name].setValue(data.name),
          this.form.controls[this.price].setValue(data.price)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let product: Product = {
        name: this.form.get(this.name).value,
        price: this.form.get(this.price).value,
        photoName: this.photoName,
        id : 0,
        lastUpdated: new Date()
      };

      this.blogPostService.saveProduct(product)
        .subscribe((data) => {
          this.router.navigate(['/']);
        });
    }

    if (this.actionType === 'Edit') {
      let product: Product = {
        id: this.existingProduct.id,
        name: this.form.get(this.name).value,
        lastUpdated: new Date() ,
        photoName: this.photoName,
        price: this.form.get(this.price.toString()).value
      };
      this.blogPostService.updateProduct(product)
        .subscribe((data) => {
          this.router.navigate(['/']);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  };

  onFileChanged(event) {
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
       this.photoName = reader.result as string;
    };
  }

  get Name() { return this.form.get(this.name); }
  get PhotoName() { return this.form.get(this.photoName); }
  get Price() { return this.form.get(this.price.toString()); }
}
