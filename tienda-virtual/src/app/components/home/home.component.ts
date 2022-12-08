import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartItem } from 'src/app/models/cartItem';
import { Product } from 'src/app/models/product';
import { ProductoService } from 'src/app/services/producto.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  productList: Product[] | undefined;
  cartProductList : CartItem [] = [];
  mensajeError: string = '';
  sub!: Subscription;
  show: boolean = false;

  constructor(
    private productoService : ProductoService,
    private route:ActivatedRoute,
    private router: Router,
    public usuarioService: UsuarioService
  ){}
  ngOnInit(): void {
    this.getProductos();
  }
  navigateTo(path: string) {
    this.router.navigate([path], { relativeTo: this.route });
  }
  showHidden() {
    this.show = !this.show;
  }
  getProductos(){
    this.sub = this.productoService.ObtenerProductos().subscribe({
      next: (productos) => {
        this.productList = productos;
      },
      error: (err) => (this.mensajeError = err),
    });
  }

  agregarProductoAlCarro(product: Product) {
    
    const productoExiste = this.cartProductList
    .find(({idProducto}) => idProducto === product.idProducto);

    console.log(productoExiste);
    if (!productoExiste) {
        let item : CartItem = {
          idProducto : product.idProducto,
          nombre: product.nombre,
          precio: product.precio,
          cantidad: 1,
          imagenUrl : product.imagenUrl
        };
      this.cartProductList.push(item);
    }else{
      productoExiste!.cantidad++;
    }
    
    console.log(this.cartProductList);
  }

  eliminarProducto(producto : CartItem) {
    this.cartProductList = this.cartProductList.filter(({idProducto}) => idProducto !== producto.idProducto)
   }

}
