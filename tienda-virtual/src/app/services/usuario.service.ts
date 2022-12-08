import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { loginCredenciales } from '../models/loginCredenciales';
import { User } from '../models/User';
import { catchError } from 'rxjs/internal/operators/catchError';


@Injectable({
    providedIn: 'root'
  })
  export class UsuarioService{
    apiBase: string = 'https://localhost:7028/api/Usuarios';

    constructor(private http: HttpClient) {
    }

    login(loginCredenciales: loginCredenciales):Observable<User>{
        return this.http.post<User>(`${this.apiBase}/login`, loginCredenciales);
    }

    registrar(nuevoUsuario: User){
        return this.http.post<User>(this.apiBase, nuevoUsuario);
    }
  }