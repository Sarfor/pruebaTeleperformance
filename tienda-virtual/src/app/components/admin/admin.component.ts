import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Product } from 'src/app/models/product';
import { ProductoService } from 'src/app/services/producto.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  productList: Product[] | undefined;
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
}
