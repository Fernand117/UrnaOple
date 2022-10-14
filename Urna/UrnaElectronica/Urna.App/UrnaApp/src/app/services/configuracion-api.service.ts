import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class ConfiguracionApiService {

  constructor(private http: HttpClient) { }

  getConfiguracion(code: any) {
    return this.http.get(`${apiUrl}eleccion/code/${code}`);
  }
}
