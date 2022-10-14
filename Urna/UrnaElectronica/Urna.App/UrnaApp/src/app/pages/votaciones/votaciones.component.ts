import { Component, OnInit,  ViewChild} from '@angular/core';

@Component({
  selector: 'app-votaciones',
  templateUrl: './votaciones.component.html',
  styleUrls: ['./votaciones.component.scss']
})
export class VotacionesComponent implements OnInit {

  constructor() { }

  @ViewChild('content') content: any;

  ngOnInit(): void {
  }

}
