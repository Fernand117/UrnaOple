using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace Votos.COMMON.DTHW
{
    public class MensajesLCD
    {
        private SerialPort arduino;
        private string mensaje { get; set; }

        public void sendMensaje(string msj)
        {
            arduino = new SerialPort();
            arduino.PortName = "COM3";
            arduino.BaudRate = 9600;
            arduino.Open();
            mensaje = msj;
            arduino.Write(mensaje);
            arduino.Close();
        }
    }
}
