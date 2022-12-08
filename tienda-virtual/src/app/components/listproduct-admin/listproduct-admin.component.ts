import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-listproduct-admin',
  templateUrl: './listproduct-admin.component.html',
  styleUrls: ['./listproduct-admin.component.css']
})
export class ListproductAdminComponent {
  @Input() productos: Product[] | undefined;

  ngOnInit(): void {
    
  }
}
