import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CartItem } from 'src/app/models/cartItem';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-card-product',
  templateUrl: './card-product.component.html',
  styleUrls: ['./card-product.component.css']
})
export class CardProductComponent {
  @Input() producto!: CartItem;
  @Output() productoEliminado = new EventEmitter();


  modelChanged(producto:Product) {
    if (this.producto.cantidad === 0) {
      this.productoEliminado.emit(this.producto)
    }
  }
}
