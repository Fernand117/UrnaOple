import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {


  //TODO: CAMBIO DE URL DEL LOCALHOST AL DE PRUEBAS DE FERNANDO
  //private url = "http://localhost:32042/api";
  //private url = "http://localhost:5000/api";
  private url = "http://74.208.95.183/api";

  constructor(
    private http: HttpClient
  ) {
  }

  uploadSignature(vals: any) {
    let data = vals;
    return this.http.post('https://api.cloudinary.com/v1_1/ddwh8eqlw/upload', data)
  }

  listaConfiguraciones() {
    return this.http.get(`${this.url}/eleccion`);
  }

  guardarConfiguracion(datos: any) {
    return this.http.post(`${this.url}/eleccion`, datos, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
  }

  guardarMecanismo(datos: any) {
    return this.http.post(`${this.url}/mecanismo`, datos, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
  }

  guardarEscolares(datos: any) {
    return this.http.post(`${this.url}/escolar`, datos, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
  }

  getOneConfiguracion(code:any) {
    return this.http.get(`${this.url}/eleccion/code/${code}`);
  }
}
