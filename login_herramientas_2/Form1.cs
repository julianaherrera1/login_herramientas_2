using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace login_herramientas_2
{
    public partial class frm_1 : Form
    {
        public frm_1()
        {
            InitializeComponent();
        }
        List<Usuario> list_datos_usuario = new List<Usuario>(); 

        private void btn_registrar_Click(object sender, EventArgs e)
        {
             // guardar lo que se digite en los textbox en una lista
             Usuario user = new Usuario();
             user.nombre_usuario = txt_usuario.Text;
             user.contraseña = txt_contraseña.Text;
             list_datos_usuario.Add(user);

             // guardar los datos de la lista en un archivo de texto 
             Usuario miUsuario = new Usuario();
             TextWriter escribir = new StreamWriter("Datos.txt",false);
             escribir.Close();
             foreach (Usuario usuario in list_datos_usuario)
             {
                 StreamWriter agregar = File.AppendText("Datos.txt");
                 agregar.WriteLine(usuario.nombre_usuario + "," + usuario.contraseña );
                 agregar.Close();
             }

        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string contraseña = txt_contraseña.Text;

            string rutaArchivo = "Datos.txt";
            string[] lineasArchivo = File.ReadAllLines(rutaArchivo);
            bool datosValidos = false;

            foreach (string line in lineasArchivo)
            {
                string[] datos = line.Split(',');
                string usuarioArchivo = datos[0];
                string contraseñaArchivo = datos[1];

                if (usuario == usuarioArchivo && contraseña == contraseñaArchivo)
                {
                    datosValidos = true;
                    break;
                }
            }

                if(datosValidos == true)
                {
                    MessageBox.Show(" Ingreso correcto ");
                }
                else
                {
                    MessageBox.Show(" Usuario incorrecto ");
                }
            }
        }
    }

