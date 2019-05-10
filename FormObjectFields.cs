using System;
using System.Windows.Forms;
using FootballLibrary;

namespace WindowsFormsApp1
{
    public enum WhatLocalAction
    {
        Ok,
        Cansel,
        Close
    }

    public partial class FormObjectFields : Form
    {
        public Control Control { get; set; }

        private FormMain _formMain;

        public WhatMainAction WhatMainAction { get; set; }

        private WhatLocalAction _whatLocalAction;

        public object CompositionObject { get; set; }

        public FormComposition FormComposition { get; set; }

        public FormObjectFields(Control control, FormMain formMain)
        {
            InitializeComponent();
            Control = control;
            _formMain = formMain;
            _whatLocalAction = WhatLocalAction.Close;
            FormComposition = new FormComposition(Control);
        }

        public void CreateObjectFields()
        {
            Control.Reflection.CreateFormFields(this, Control);
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Control.Reflection.SetPropertyValues(this, Control.CurrObject);
            if (WhatMainAction == WhatMainAction.Add)
                _formMain.AddObject(Control.CurrObject);
            _whatLocalAction = WhatLocalAction.Ok;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            _whatLocalAction = WhatLocalAction.Cansel;
            this.Close();
        }

        private void FormObjectFields_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((WhatMainAction == WhatMainAction.Add) &&
                    ((_whatLocalAction == WhatLocalAction.Cansel) || (_whatLocalAction == WhatLocalAction.Close)))
            {
                IFootball removeobject = Control.CurrObject;
                Control.CurrObject.Remove(ref removeobject);
            }
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

        private void ButtonComposition_Click(object sender, EventArgs e)
        {
            this.FormComposition.CreateObjectFields();
            this.FormComposition.ShowDialog();
        }
    }
}