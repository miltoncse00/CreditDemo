import { Component, OnInit } from '@angular/core'
import { DemoService } from '../../shared/demoService';
import { SalesModel } from '../../shared/sales.model';


@Component({
  selector: 'list-sales',
  templateUrl: './listSales.component.html'
})


export class ListSalesComponent implements OnInit {

  Sales: SalesModel[];
  ngOnInit(): void {
    this.Sales = [];
    this.demoService.getSales().subscribe(
      (data) => {
        this.Sales = data;
      }
    )
  }
  constructor(private demoService: DemoService) { }


}
