import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class MecanismosModule {
  public TipoMecanismo: string;
  public Nombre: string;
  public Objeto: string;
  public CantidadBoletas: string;
  public Presidente: string;
  public Secretario: string;
  public PrimerEscrutador: string;
  public SegundoEscrutador: string;
  public Entidad: string;
  public Distrito: string;
  public Municipio: string;
  public Seccion: string;
  public Folio: string;
  public Firmas: any[];
  public Preguntas: any[];
}
