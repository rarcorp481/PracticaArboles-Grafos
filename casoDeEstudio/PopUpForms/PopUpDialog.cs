using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casoDeEstudio.PopUpForms
{
    public class PopUpDialog
    {
        /// <summary>
        /// Loads a pop-up dialog to get user input with validation for non-empty input.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="titulo"></param>
        /// <returns></returns>
        public static string ShowInputDialog(string texto, string titulo)
        {
            // Configuración del formulario
            int anchoForm = 400;
            int margen = 20; 
            int anchoUtil = anchoForm - (margen * 2);

            //Creamos el formulario con el nombre 'prompt'
            Form prompt = new Form()
            {
                Width = anchoForm, 
                Height = 200, 
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = margen, 
                Top = 20,
                Text = texto,
                AutoSize = true,
                MaximumSize = new Size(anchoUtil, 0) 
            };

            prompt.Controls.Add(textLabel); 

            int espacioY = textLabel.Bottom + 15; 

            TextBox textBox = new TextBox() { Left = margen, Top = espacioY, Width = anchoUtil }; 
            Button confirmation = new Button() { Text = "Aceptar", Left = 240, Width = 100, Top = espacioY + 35 }; 

            prompt.Height = confirmation.Bottom + 50; 

            confirmation.DialogResult = DialogResult.None;

            // Validación para asegurar que el TextBox no esté vacío
            confirmation.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("¡El nombre es obligatorio!", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                }
                else
                {
                    prompt.DialogResult = DialogResult.OK;
                    prompt.Close();
                }
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";

        }
    }
}
