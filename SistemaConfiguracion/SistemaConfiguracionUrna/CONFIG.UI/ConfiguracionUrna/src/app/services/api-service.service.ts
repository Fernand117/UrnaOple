import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  private url = "http://localhost:5000/api/eleccion";

  constructor(
    private http: HttpClient
  ) { }

  uploadSignature(vals: any) {
    let data = vals;
    return this.http.post('https://api.cloudinary.com/v1_1/ddwh8eqlw/upload',data)
  }

  guardarConfiguracion(datos: any) {
    return this.http.post(this.url, datos, {headers : new HttpHeaders({ 'Content-Type': 'application/json' })});
  }
}
