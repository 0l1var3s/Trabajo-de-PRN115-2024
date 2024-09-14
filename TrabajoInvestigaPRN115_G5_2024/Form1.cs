using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoInvestigaPRN115_G5_2024
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor del formulario. Inicializa los componentes y agrega las operaciones al ComboBox.
        /// También establece el campo de resultado como de solo lectura.
        /// </summary>
        public Form1()
        {
            //agrega al combo box los items a utilizar
            InitializeComponent();
            CBoxOperaciones.Items.Add("Sumar");
            CBoxOperaciones.Items.Add("Restar");
            CBoxOperaciones.Items.Add("Multiplicar");
            CBoxOperaciones.Items.Add("Dividir");

            //hace que el TextBox sea solo lectura
            txtResultado.ReadOnly = true;
        }
        /// <summary>
        /// Este método se ejecuta al hacer clic en el botón 'Ejecutar'.
        /// Realiza la operación seleccionada (sumar, restar, multiplicar o dividir) sobre dos números ingresados.
        /// </summary>
       
        /// <remarks>
        /// Si se selecciona "Dividir", se verifica que el segundo número no sea 0 para evitar divisiones entre 0.
        /// Si los valores ingresados no son números válidos, se muestra un mensaje de advertencia.
        /// </remarks>
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            double numero1, numero2, resultado = 0;

            // Intentar convertir los valores de los TextBox en números.
            if (double.TryParse(txtNumero1.Text, out numero1) && double.TryParse(txtNumero2.Text, out numero2))
            {
                string operacionSeleccionada = CBoxOperaciones.SelectedItem?.ToString(); // Manejo seguro de la selección.

                // Evaluar la operación seleccionada.
                switch (operacionSeleccionada)
                {
                    case "Sumar":
                        resultado = numero1 + numero2;
                        break;
                    case "Restar":
                        resultado = numero1 - numero2;
                        break;
                    case "Multiplicar":
                        resultado = numero1 * numero2;
                        break;
                    case "Dividir":
                        if (numero2 != 0) // Verificar que no se divida entre 0
                        {
                            resultado = numero1 / numero2;
                        }
                        else
                        {
                            MessageBox.Show("No se puede dividir entre 0.");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Selecciona una operación válida.");
                        return;
                }

                // Mostrar el resultado en el TextBox de resultado.
                txtResultado.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Introduce números válidos.");
            }
        }

        private void CBoxOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Limpia todos los campos de entrada (números y operación) al hacer clic en el botón 'Limpiar'.
        /// </summary>

        /// <remarks>
        /// Restablece los campos `txtNumero1`, `txtNumero2` y `txtResultado`.
        /// También elimina la selección del ComboBox de operaciones.
        /// </remarks>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            txtResultado.Text = "";
            CBoxOperaciones.SelectedIndex = -1; // Desmarcar la selección del ComboBox
        }
        /// <summary>
        /// Cierra el formulario cuando se presiona el botón 'Cerrar'.
        /// </summary>

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
