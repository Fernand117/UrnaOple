import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
  
  setR(voto: any) {
    return this.http.post(`${apiUrl_local}referendum`, voto);
  }
}
