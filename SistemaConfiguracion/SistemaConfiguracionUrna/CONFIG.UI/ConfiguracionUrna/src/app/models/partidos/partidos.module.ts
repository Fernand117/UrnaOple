import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class PartidosModule {
  public Id: number;
  public Logotipo: string;
  public Propietario: string;
  public Suplente: string;
  public Hipocoristico: string;
  public Cargo: string;
  public TipoCandidatura: string;
}
