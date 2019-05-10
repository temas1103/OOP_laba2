using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormComposition : Form
    {
        private Control _control;

        public FormComposition(Control control)
        {
            InitializeComponent();
            _control = control;
        }

        public void CreateObjectFields()
        {
            _control.Reflection.CreateFormFields(this, _control.CompositionObject);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            _control.Reflection.SetPropertyValues(this, _control.CompositionObject);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComposition_FormClosed(object sender, FormClosedEventArgs e)
        {
            int i = 0;
            while (i < this.Controls.Count)
            {
                if (this.Controls[i] is TextBox textBox)
                {
                    this.Controls.Remove(textBox);
                }
                else if (this.Controls[i] is Label label)
                {
                    this.Controls.Remove(label);
                }
                else if (this.Controls[i] is ComboBox comboBox)
                {
                    this.Controls.Remove(comboBox);
                }
                else
                    i++;
            }
        }
    }
}