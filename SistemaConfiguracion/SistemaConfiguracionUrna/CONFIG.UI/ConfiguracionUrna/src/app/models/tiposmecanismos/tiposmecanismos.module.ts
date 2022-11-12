import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class TiposmecanismosModule {
  public TipoMecanismo: string;
  public Nombre: string;
  public Objeto: string;
  public CantidadBoletas: string;
  public Folio: string;
  public Preguntas: any[];

  constructor() {
    this.TipoMecanismo = "";
    this.Nombre = "";
    this.Objeto = "";
    this.CantidadBoletas = "";
    this.Folio = "";
    this.Preguntas = [];
  }
}
