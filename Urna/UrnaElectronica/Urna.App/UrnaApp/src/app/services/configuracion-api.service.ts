import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

const apiUrl = environment.apiUrl;
const apiUrl_local = environment.apiUrl_local;

@Injectable({
  providedIn: 'root'
})
export class ConfiguracionApiService {

  constructor(private http: HttpClient) { }

  getConfiguracion(code: any) {
    return this.http.get(`${apiUrl}eleccion/code/${code}`);
  }

  setVoto(voto: any, ruta: string) {
    return this.http.post(`${apiUrl_local}${ruta}`, voto);
  }

  contadorBoletas(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/`, boleta);
  }

  updateContadorBoletas(boleta: any) {
    return this.http.put(`${apiUrl_local}boletas/`, boleta);
  }

  getContadorBoletas() {
    return this.http.get(`${apiUrl_local}boletas`)
  }

  imprimirBoleta(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletainicial`, boleta);
  }
  
}
