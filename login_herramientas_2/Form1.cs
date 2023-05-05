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
        private int intentos = 0;


        //  MINIMIZAR Y MAXIMIZAR FORMULARIO
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // registrar usuario
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                // validar que no hayan campos vacios 
                if(txt_usuario.Text == "" || txt_contraseña.Text == "")
                {
                    MessageBox.Show(" ERROR :  NO INGRESO DATOS");
                }
                else
                {
                    // guardar lo que se digite en los textbox en una lista
                    Usuario user = new Usuario();
                    user.nombre_usuario = txt_usuario.Text;
                    user.contraseña = txt_contraseña.Text;
                    list_datos_usuario.Add(user);

                    // guardar los datos de la lista en un archivo de texto 
                    Usuario miUsuario = new Usuario();
                    TextWriter escribir = new StreamWriter("Datos.txt", false);
                    escribir.Close();
                    foreach (Usuario usuario in list_datos_usuario)
                    {
                        StreamWriter agregar = File.AppendText("Datos.txt");
                        agregar.WriteLine(usuario.nombre_usuario + "," + usuario.contraseña);
                        agregar.Close();
                    }
                    MessageBox.Show(" USUARIO REGISTRADO CON EXITO!");
                    limpiar();
                }
               
            }
            catch (Exception )
            {
                MessageBox.Show(" ERROR : TIPO DE DATO NO PERMITIDO ");
            }
           

        }

        // METODO LIMPIAR TEXTBOX
        private void limpiar()
        {
            txt_usuario.Text = "";
            txt_contraseña.Text = "";
            txt_usuario.Focus();
        }



        // iniciar sesion 
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
        try
        { // validar que los campos no esten vacios 
            if(txt_usuario.Text == "" || txt_contraseña.Text == "")
            {
              MessageBox.Show(" ERROR : NO INGRESO NINGUN DATO");
            } 
            else
            {
              if (intentos < 3)
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

                        
              if (datosValidos == true)
                {
                 MessageBox.Show(" Ingreso correcto, ¡Bienvenido! ");
                  intentos = 0;
                 }else
                     {
                       intentos++;
                       MessageBox.Show(" Usuario o contraseña incorrectos ");
                            if (intentos == 3)
                            {
                                btn_ingresar.Enabled = false;
                                MessageBox.Show(" Ya ha intentando iniciar sesion 3 veces ");
                            }
                        }
                    }

                }
               

            }
            catch (Exception)
            {
                MessageBox.Show(" ERROR : TIPO DE DATO NO PERMITIDO ");
            }
          
        }

        private void img_ver_contraseña_Click(object sender, EventArgs e)
        {
            if(txt_contraseña.PasswordChar == '*')
            {
                // mostrar contraseña
                txt_contraseña.PasswordChar = '\0';
            }
            else
            {
                // ocultar contraseña
                txt_contraseña.PasswordChar = '*';
            }
        }
    }
}

