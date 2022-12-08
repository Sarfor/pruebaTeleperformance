export interface User{
    idUsuario: number;
    documento:string;
    nombre: string;
    apellido: string;
    email: string;
    clave: string;
    esActivo: boolean;
    idRol: number;
}