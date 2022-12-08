import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {
  
@Input() producto!: Product;
@Output() productoAgregado = new EventEmitter();

agregarProductoAlCarro(producto : Product) {
  this.productoAgregado.emit(producto);
}
    
  ngOnInit(): void {
    console.log(this.producto);
  }
  
}
