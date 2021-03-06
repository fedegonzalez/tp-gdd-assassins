﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class inicioAdministrador : Form
    {
        public inicioAdministrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.abmAeronave abrir = new Abm_Aeronave.abmAeronave();
            abrir.Show();
        }

        private void buttonCiudades_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.abmCiudad abrir = new Abm_Ciudad.abmCiudad();
            abrir.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Abm_Rol.abmRol abrir = new Abm_Rol.abmRol();
            abrir.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Abm_Ruta.abmRuta abrir = new Abm_Ruta.abmRuta();
            abrir.Show();
        }

        private void buttonGenerarViaje_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.generacionViaje abrir = new Generacion_Viaje.generacionViaje();
            abrir.Show();
        }

        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            Registro_Llegada_Destino.registroLlegadaDestino abrir = new Registro_Llegada_Destino.registroLlegadaDestino();
            abrir.Show();
        }

        private void buttonCompra_Click(object sender, EventArgs e)
        {
            Compra.compra abrir = new Compra.compra(false);
            abrir.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Devolucion.devolucion abrir = new Devolucion.devolucion();
            abrir.Show();
        }

        private void buttonListado_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.listadoEstadistico abrir = new Listado_Estadistico.listadoEstadistico();
            abrir.Show();
        }

        private void buttonCanje_Click(object sender, EventArgs e)
        {
            Canje_Millas.canjeMillas abrirCliente = new Canje_Millas.canjeMillas();
            abrirCliente.Show();
        }
    }
}
