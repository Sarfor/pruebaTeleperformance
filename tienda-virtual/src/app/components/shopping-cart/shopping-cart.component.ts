import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CartItem } from 'src/app/models/cartItem';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent {
  @Input() productos: CartItem[] | undefined;
  @Output() productoEliminado = new EventEmitter();

  cantidadItems() {
    return this.productos?.reduce((sum, prod) => sum += prod.cantidad ,0)
  }
  total(){
    return this.productos?.reduce((sum, prod) => sum += (prod.cantidad * prod.precio) ,0)
  }

  eliminarProducto(producto : CartItem) {
    this.productoEliminado.emit(producto)
  }
  modelChanged(producto:CartItem) {
    if (producto.cantidad === 0) {
      this.productoEliminado.emit(producto)
    }
  }
  calcularPrecio(producto:CartItem){
    return producto.cantidad * producto.precio;
  }
}
