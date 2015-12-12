using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AerolineaFrba.Compra
{
    public partial class listadoViajes : Form
    {
        public listadoViajes(Compra.compra form, string fecha, string origen, string destino)
        {
            InitializeComponent();
            _form1 = form;
            fechasql = fecha;
            cOrigen = origen;
            cDestino = destino;
        }

        public compra _form1;
        string fechasql;
        string cOrigen;
        string cDestino;

        private void listadoViajes_Load(object sender, EventArgs e)
        {
            string query = "SELECT vi.Viaje_ID, (ae.Aeronave_Butacas_Pasillo+" +
            "ae.Aeronave_Butacas_Ventana)-COUNT(DISTINCT Butaca_ID) butacas_libres, ae.Aeronave_KG_Capacidad-(SELECT SUM"+
            "(Cantidad_KG) FROM ASSASSINS.Encomienda WHERE Viaje_ID = vi.Viaje_ID) kg_libres, tipo.TipoServ_Nombre FROM ASSASSINS.Viaje vi "+
            "LEFT JOIN ASSASSINS.Aeronave ae ON(ae.Aeronave_Numero=vi.Aeronave_Numero) LEFT JOIN ASSASSINS.Pasaje pa "+
            "ON(vi.Viaje_ID=pa.Viaje_ID) LEFT JOIN ASSASSINS.Ruta ru ON(ru.Ruta_ID=vi.Ruta_ID) LEFT JOIN ASSASSINS.Ciudad"+
            " dest ON(dest.Ciudad_ID=Ruta_Ciudad_Destino) LEFT JOIN ASSASSINS.Ciudad orig ON(orig.Ciudad_ID=Ruta_Ciudad_Origen)"+
            "LEFT JOIN ASSASSINS.Tipo_Servicio tipo ON(tipo.TipoServ_ID=ae.TipoServ_ID)"+
            " WHERE CAST(vi.Viaje_Fecha_Salida AS DATE) = CAST('" + fechasql + "' AS DATE) AND " +
            "dest.Ciudad_Nombre like '%" + cDestino + "%' AND orig.Ciudad_Nombre like '%" + cOrigen + 
            "%' GROUP BY tipo.TipoServ_Nombre, vi.Viaje_ID, ae.Aeronave_Butacas_Pasillo, ae.Aeronave_Butacas_Ventana, ae.Aeronave_KG_Capacidad";

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    connection.Open();
                    var myTable = new DataTable();
                    adapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _form1.viaje = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            _form1.butaca = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            _form1.kg = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            this.Hide();
        }
    }
}
