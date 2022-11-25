import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxQrcodeElementTypes, NgxQrcodeErrorCorrectionLevels } from '@techiediaries/ngx-qrcode';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-acta-cierre',
  templateUrl: './acta-cierre.component.html',
  styleUrls: ['./acta-cierre.component.scss']
})
export class ActaCierreComponent implements OnInit {

  config_gubernatura?: any;
  config_ayuntamiento?: any;
  config_diputacion?: any;
  config_escolares?: any;
  config_referendum?: any;
  config_plebiscito?: any;
  config_consulta?: any;
  configuracion_general: any;
  votosgub: any;
  votosayu: any;
  votosdip: any;
  votosref: any;
  votosples: any;
  votoscons: any;
  votosesc: any;
  votosRequest: any;
  resPic: any;

  title = 'OPLE';
  elementType = NgxQrcodeElementTypes.URL;
  errorCorrectionLevel = NgxQrcodeErrorCorrectionLevels.HIGH;
  value = `https://resultadosople.web.app/resultados/code/${localStorage.getItem('codigo')}`;
  valor = "codigoqr" + localStorage.getItem('codigo')?.toString();

  //IMAGEN QR
  private formData: any;
  date: Date = new Date();
  imagenCreada: any;

  listaResultados: any[] = [];

  constructor(private route: Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    this.votosAyu();
    this.votosDip();
    this.votosGub();
    this.votosPlesbicito();
    this.votosConsulta();
    this.votosReferendum();
    this.resultadosEsc();
    setTimeout(()=>{
      this.crearImagen();
    }, 500);
  }

  //CONVERTIR Y ENVIAR LA IMAGEN DEL CÓDIGO QR AL SERVIDOR
  crearImagen() {
    let doc = document.querySelector("#qr") as HTMLElement;
    html2canvas(doc).then(canvas => {
      this.imagenCreada = canvas.toDataURL();
      this.formData = new FormData();
      this.formData.append('file', this.imagenCreada);
      this.formData.append('public_id', this.valor + "" + "696242651689144");
      this.formData.append('upload_preset', 'filesOple');
      this.service.uploadSignature(this.formData).subscribe(
        res => {
          this.resPic = res;
          this.resPic = this.resPic.url;
        }
      );
    }).then(() => {
      this.enviarResultados();
    });
  }

  enviarResultados() {
    const resultados = {
      "Codigo": localStorage.getItem('codigo'),
      "Categoria": localStorage.getItem('categoria'),
      "Resultados": this.listaResultados
    }
    this.service.sendResultados(resultados).subscribe((resp) => {
    })
  }

  obtenerVotos(votos: any) {
    this.votosRequest = votos;
  }

  imprimirBoleta(configuracion: any) {
    this.configuracion_general.Partidos = this.votosRequest;
    this.configuracion_general.TipoEleccion = configuracion.TipoEleccion;
    this.configuracion_general.Folio = configuracion.Folio;
    this.configuracion_general.CantidadBoletas = configuracion.CantidadBoletas;
    this.configuracion_general.QrCode = this.resPic;
    delete this.configuracion_general['Elecciones'];
    this.service.imprimirBoletaFinal(this.configuracion_general).subscribe(resp => {
    });
  }

  imprimirBoletaMecanismos(configuracion: any) {
    this.configuracion_general.Preguntas = this.votosRequest;
    this.configuracion_general.MecanismoTipo = configuracion.MecanismoTipo;
    this.configuracion_general.Folio = configuracion.Folio;
    this.configuracion_general.QrCode = this.resPic;
    delete this.configuracion_general['TipoMecanismos'];
    this.service.imprimirBoletaFinalMecanismos(this.configuracion_general).subscribe(resp => {
    });

  }

  imprimirBoletaEscolares(configuracion: any) {
    this.configuracion_general.Partidos = this.votosRequest;
    this.configuracion_general.QrCode = this.resPic;
    this.service.imprimirBoletaFinalEscolares(this.configuracion_general).subscribe(resp => {
    });
  }

  votosGub() {
    this.service.getVotosByTipo('gubernatura').subscribe(resp => {
      this.votosgub = resp;
      this.votosgub = this.votosgub.data;
      if (Object.entries(this.votosgub).length > 0) {
        const datos = {
          "TipoEleccion": "Gubernaturas",
          "Datos": this.votosgub
        };
        this.listaResultados.push(datos);
      }
    });
  }

  votosDip() {
    this.service.getVotosByTipo('diputacion').subscribe(resp => {
      this.votosdip = resp;
      this.votosdip = this.votosdip.data;
      if (Object.entries(this.votosdip).length > 0) {
        const datos = {
          "TipoEleccion": "Diputaciones",
          "Datos": this.votosdip
        };
        this.listaResultados.push(datos);
      }
    });
  }

  votosAyu() {
    this.service.getVotosByTipo('ayuntamiento').subscribe(resp => {
      this.votosayu = resp;
      this.votosayu = this.votosayu.data;
      if (Object.entries(this.votosayu).length > 0) {
        const datos = {
          "TipoEleccion": "Ayuntamientos",
          "Datos": this.votosayu
        };
        this.listaResultados.push(datos);
      }
    });
  }

  votosPlesbicito() {
    this.service.getVotosByTipo("presbicito").subscribe(resp => {
      this.votosples = resp;
      this.votosples = this.votosples.data;
      if (Object.entries(this.votosples).length > 0) {
        let arreglado = this.votosples.map((p: any) => {
          p[`partido`] = p.pregunta;
          delete p.pregunta;
          return p;
        });
        const datos = {
          "TipoEleccion": "Presbicito",
          "Datos": arreglado
        };
        this.listaResultados.push(datos);
      }
    });
  }

  votosConsulta() {
    this.service.getVotosByTipo("consulta").subscribe(resp => {
      this.votoscons = resp;
      this.votoscons = this.votoscons.data;
      if (Object.entries(this.votoscons).length > 0) {
        let arreglado = this.votoscons.map((p: any) => {
          p[`partido`] = p.pregunta;
          delete p.pregunta;
          return p;
        });
        const datos = {
          "TipoEleccion": "Consulta",
          "Datos": arreglado
        };
        this.listaResultados.push(datos);
      }

    });
  }

  votosReferendum() {
    this.service.getVotosByTipo("referendum").subscribe(resp => {
      this.votosref = resp;
      this.votosref = this.votosref.data;
      if (Object.entries(this.votosref).length > 0) {
        let arreglado = this.votosref.map((p: any) => {
          p[`partido`] = p.pregunta;
          delete p.pregunta;
          return p;
        });
        const datos = {
          "TipoEleccion": "Referendum",
          "Datos": arreglado
        };
        this.listaResultados.push(datos);
      }
    });
  }

  resultadosEsc() {
    this.service.getVotosByTipo('escolar').subscribe(resp => {
      this.votosesc = resp;
      this.votosesc = this.votosesc.data;
      if (Object.entries(this.votosesc).length > 0) {
        const datos = {
          "TipoEleccion": "Escolares",
          "Datos": this.votosesc
        };
        this.listaResultados.push(datos);
      }
    });
  }

  obtenerConfiguracion() {
    this.configuracion_general = localStorage.getItem('configeneral');
    this.configuracion_general = JSON.parse(this.configuracion_general);
    //CONFIGURACIONES PARA ELECCIONALES LOCALES
    this.config_gubernatura = localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);
    this.config_ayuntamiento = localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);
    this.config_diputacion = localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);

    //CONFIGURACIÓN ELECCIONES ESCOLARES
    this.config_escolares = localStorage.getItem('escolares');
    this.config_escolares = JSON.parse(this.config_escolares);

    //CONFIGURACIONES MECANISMOS DE PARTICIPACIÓN CIUDADANA
    this.config_referendum = localStorage.getItem('referendum');
    this.config_referendum = JSON.parse(this.config_referendum);
    this.config_plebiscito = localStorage.getItem('presbicito');
    this.config_plebiscito = JSON.parse(this.config_plebiscito);
    this.config_consulta = localStorage.getItem('consulta');
    this.config_consulta = JSON.parse(this.config_consulta);
  }

  finalizar() {
    this.route.navigate(['/bienvenido']);
  }

}
