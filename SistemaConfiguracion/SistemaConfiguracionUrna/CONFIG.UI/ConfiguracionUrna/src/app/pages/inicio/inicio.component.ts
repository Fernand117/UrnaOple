import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent implements OnInit {

  private resData: any;

  constructor(
    private apiService: ApiServiceService
  ) { }

  ngOnInit(): void {
    this.apiService.listaConfiguraciones().subscribe(
      res => {
        this.resData = res;
        let jsonRes = JSON.parse(this.resData['data'][0]['configuraciones']);
        let json = JSON.parse(jsonRes['Configuraciones']);
        //console.log(this.resData);
        console.log(json)
      }
    );
  }

}
