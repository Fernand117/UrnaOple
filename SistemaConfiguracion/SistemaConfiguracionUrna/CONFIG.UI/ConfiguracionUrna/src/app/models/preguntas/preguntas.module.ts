import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class PreguntasModule {
  public Pregunta: string;
  constructor() {
    this.Pregunta = "";
  }
}
