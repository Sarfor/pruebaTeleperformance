import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  @Input() productos: Product[] | undefined;
  @Output() productoAgregado = new EventEmitter();

agregarProductoAlCarro(producto : Product) {
  this.productoAgregado.emit(producto);
}

  ngOnInit(): void {
    
  }
}
