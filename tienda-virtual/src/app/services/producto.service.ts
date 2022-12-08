import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { loginCredenciales } from '../models/loginCredenciales';
import { Product } from '../models/product';


@Injectable({
    providedIn: 'root'
  })
  export class ProductoService{
    apiBase: string = 'https://localhost:7028/api/Productos';
    constructor(private http: HttpClient) {
    }

    ObtenerProductos():Observable<Product[]>{
        return this.http.get<Product[]>(this.apiBase);
    }

    guardarProducto(nuevoProducto:FormData):Observable<any>{
      return this.http.post(this.apiBase, nuevoProducto);
    }

  }