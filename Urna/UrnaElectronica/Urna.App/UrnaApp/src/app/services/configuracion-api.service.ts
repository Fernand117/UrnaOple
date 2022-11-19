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

  //OBTENER TODA LA INFORMACIÓN MEDIANTE EL CÓDIGO DE CONFIGURACIÓN
  getConfiguracion(code: any) {
    return this.http.get(`${apiUrl}eleccion/code/${code}`);
  }

  //REGISTRAR EL VOTO DE CADA VOTANTE EN LA BASE DE DATOS
  setVoto(voto: any, ruta: string) {
    return this.http.post(`${apiUrl_local}${ruta}`, voto);
  }

  //INSERTAR EL NÚMERO DE BOLETAS
  contadorBoletas(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/`, boleta);
  }

  //DECREMENTAR EL NÚMERO DE BOLETAS ACTUAL POR CADA VOTO QUE SE REALICE  
  updateContadorBoletas(boleta: any) {
    return this.http.put(`${apiUrl_local}boletas/`, boleta);
  }

  //OBTENER EL NÚMERO DE BOLETAS ACTUAL 
  getContadorBoletas() {
    return this.http.get(`${apiUrl_local}boletas`)
  }

  //IMPRIMIR BOLETAS DE INICIALIZACIÓN 
  imprimirBoleta(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletainicial`, boleta);
  }

  imprimirBoletaMecanismos(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletainicialmecanismos`, boleta);
  }

  imprimirBoletaEscolares(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletainicialescolares`, boleta);
  }

  //IMPRIMIR BOLETAS DE CIERRE

  imprimirBoletaFinal(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletafinal`, boleta);
  }

  imprimirBoletaFinalMecanismos(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletafinalmecanismos`, boleta);
  }
  
  imprimirBoletaFinalEscolares(boleta: any) {
    return this.http.post(`${apiUrl_local}boletas/imprimir/boletafinalescolares`, boleta);
  }

  //ELIMINAR DATOS DE LA BASE DE DATOS PARA INICIAR OTRO PROCESO DE VOTACIÓN 
  deleteDataBoletas() {
    return this.http.delete(`${apiUrl_local}boletas`);
  }

  //OBTENER EL NÚMERO DE VOTOS TOTAL 
  getVotosByTipo(ruta: any) {
    return this.http.get(`${apiUrl_local}${ruta}`);
  }

  //ENVIAR IMAGEN QR AL SERVIDOR DE CLOUDINARY
  uploadSignature(vals: any) {
    let data = vals;
    return this.http.post('https://api.cloudinary.com/v1_1/ddwh8eqlw/upload', data)
  }

  //ENVIAR RESULTADOS AL API DEL SERVIDOR 
  sendResultados(resu: any) {
    return this.http.post(`${apiUrl}resultados`, resu)
  }
  
}
