import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { SalesModel } from '../../shared/sales.model';
import { DemoService } from '../../shared/demoService';
import { Observable } from 'rxjs/Observable';
import { HttpErrorResponse } from '@angular/common/http';
import { T } from '@angular/core/src/render3';

@Component({
  selector: 'add-sales',
  templateUrl: './addSales.component.html',
  styleUrls: ['./addSales.component.css']
})
export class AddSalesComponent implements OnInit {
  constructor(private fb: FormBuilder, private demoService: DemoService) { }
  myForm: FormGroup;
  successfulSave: boolean;
  errors: string[];
  ngOnInit(): void {
    this.errors = [];
    var saleId: number;
    this.demoService.getSaleId().subscribe(
      (data) => {
        saleId = data;
        this.myForm.controls['id'].setValue(saleId);
      });
    this.myForm = this.fb.group({
      id: new FormControl(saleId, [Validators.required, Validators.maxLength(12)]),
      customer_id: new FormControl('', [Validators.required, Validators.maxLength(12)]),
      location_name: new FormControl('', Validators.maxLength(500)),
      operator_name: new FormControl('', [Validators.required, Validators.maxLength(500)]),
      opening_debt: new FormControl(0, [Validators.min(0), Validators.max(99999999.99)]),
      currency: new FormControl('', Validators.maxLength(50)),
      sale_invoice_number: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      payments: this.fb.array([this.buildItem()])
    })

    
  }

  currentDate() {
    const currentDate = new Date();
    return currentDate.toISOString().substring(0, 10);
  }


 

  submit = () => {
    if (this.myForm.valid) {
      this.demoService.saveSales(this.myForm.value).subscribe(
        (data: boolean) => {

          this.successfulSave = true;

        },
        (err: HttpErrorResponse) => {
          
          if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            this.errors.push(err.error.message);
          } else {
            if (err.status == 400) {
              var json = JSON.stringify(err.error);
              let validationErrorDictionary = JSON.parse(json);
              for (var fieldName in err.error) {
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                }
              }
            } else {
              this.errors.push("something went wrong!");
            }
          }
        });
    }


  }
  buildItem() {
    return new FormGroup({
      payment_date: new FormControl(this.currentDate(), Validators.required),
      description: new FormControl('', Validators.maxLength(500)),
      payment_amount: new FormControl(0, [Validators.min(0), Validators.max(99999999.99), Validators.required])
    })
  }
}
