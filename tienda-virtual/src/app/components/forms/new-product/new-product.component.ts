import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ProductoService } from 'src/app/services/producto.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {
  constructor(private productoService : ProductoService){}
  selectedFile!: File;
  newProductForm!: FormGroup;

  mensajeError: string = '';
  sub!: Subscription;

  ngOnInit(): void {
    this.newProductForm = new FormGroup({
      Nombre: new FormControl(null),
      Stock: new FormControl(null),
      Precio: new FormControl(null),
      Descripcion: new FormControl(null),
      Imagen: new FormControl(null)
    });
  }

  onSelectFile(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0];
  }
  onSubmit(data:any){
    const formData = new FormData();
    formData.append('Nombre', data.Nombre);
    formData.append('Stock', data.Stock);
    formData.append('Precio', data.Precio);
    formData.append('Descripcion', data.Descripcion);
    formData.append('Imagen', this.selectedFile);
    this.sub = this.productoService.guardarProducto(formData).subscribe({
      next: () => {
        Swal.fire({
          icon: 'success',
          width: '200px',
          showConfirmButton: false,
          timer: 1500,
        });
      },
      error: (err) => {
        Swal.fire({
          icon: 'error',
          width: '200px',
          showConfirmButton: false,
          timer: 1500,
          text: "Error guardando producto"
        });
      },
    });

    this.newProductForm.reset();
  }
}
