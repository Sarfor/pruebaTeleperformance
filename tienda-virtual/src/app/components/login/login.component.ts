import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/User';
import { loginCredenciales } from 'src/app/models/loginCredenciales';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  constructor(private usuarioService: UsuarioService, private route: Router) {}
  pageTitle: string = 'iniciar sesión';

  user: loginCredenciales = {
    email: '',
    clave: '',
  };

  mensajeError: string = '';
  sub!: Subscription;

  login(): void {
    this.sub = this.usuarioService.login(this.user).subscribe({
      next: (userInfo) => {
        Swal.fire({
          icon: 'success',
          width: '200px',
          showConfirmButton: false,
          timer: 1500,
        });
        this.enrutarPorPerfil(userInfo);
      },
      error: (err) => (this.mensajeError = err),
    });
  }
  enrutarPorPerfil(user: User): void {
    switch (user.idRol) {
      case 1:
        this.route.navigate(['/admin', user.idUsuario]);
        break;
      case 2:
        this.route.navigate(['/home', user.idUsuario]);
        break;
      default:
        this.mensajeError = 'Perfil no identificado';
        break;
    }
  }
  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
