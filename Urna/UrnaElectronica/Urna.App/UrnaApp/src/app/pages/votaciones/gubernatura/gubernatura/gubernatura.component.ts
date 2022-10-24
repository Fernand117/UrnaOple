import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-gubernatura',
  templateUrl: './gubernatura.component.html',
  styleUrls: ['./gubernatura.component.scss']
})
export class GubernaturaComponent implements OnInit {

  @Output() miEvento = new EventEmitter<boolean>();
  voto: boolean = false;

  @Input() partidos: any;
  app_name: string = "gubernatura";

  constructor() { }

  ngOnInit(): void { }

  getVoto(e: any) {
    this.voto = e;
    this.miEvento.emit(this.voto);
  }
  
}
