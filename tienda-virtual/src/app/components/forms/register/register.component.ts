import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/User';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user: User = {
    nombre: '',
    apellido: '',
    documento: '',
    email: '',
    clave: '',
    idUsuario: 0,
    esActivo: false,
    idRol: 0
  };

  mensajeError: string = '';
  sub!: Subscription;

  constructor(private usuarioService: UsuarioService, private route: Router) {}

  registrar():void{
    this.sub = this.usuarioService.registrar(this.user).subscribe({
      next: () => {
        Swal.fire({
          icon: 'success',
          width: '200px',
          showConfirmButton: false,
          timer: 1500,
        });
      },
      error: (err) => (this.mensajeError = err),
    });
  }
}
