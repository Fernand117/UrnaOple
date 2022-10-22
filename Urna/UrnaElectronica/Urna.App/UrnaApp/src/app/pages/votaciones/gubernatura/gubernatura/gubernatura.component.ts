import { Component, OnInit, Input} from '@angular/core';

@Component({
  selector: 'app-gubernatura',
  templateUrl: './gubernatura.component.html',
  styleUrls: ['./gubernatura.component.scss']
})
export class GubernaturaComponent implements OnInit {

  constructor() { }

  @Input() partidos: any;
  app_name: string = "gubernatura";

  ngOnInit(): void {    
  }

}
