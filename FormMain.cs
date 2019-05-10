using System;
using System.Windows.Forms;
using FootballLibrary;

namespace WindowsFormsApp1
{
    public enum WhatMainAction
    {
        Add,
        Change
    }

    public partial class FormMain : Form
    {
        public Control Control { get; set; }

        public FormObjectFields FormObjectFields { get; set; }

        public FormMain()
        {
            InitializeComponent();
            this.Control = new Control();
            this.comboBoxAvailableTypes.Items.AddRange(Control.FootballFactories);
            this.FormObjectFields = new FormObjectFields(Control, this);
            Control.CreateStartObjects();
            foreach (var obj in Control.ApplicationObjects)
            {
                listBox.Items.Add(obj);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Control.CreateObject(comboBoxAvailableTypes.SelectedIndex);
            FormObjectFields.WhatMainAction = WhatMainAction.Add;
            FormObjectFields.CreateObjectFields();
            FormObjectFields.ShowDialog();
        }

        public void AddObject(IFootball footballObject)
        {
            Control.AddObject(footballObject);
            listBox.Items.Add(footballObject);
            listBox.SelectedItem = footballObject;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                int selectedIndex = listBox.SelectedIndex;
                Control.CurrObject = listBox.SelectedItem as IFootball;
                FormObjectFields.WhatMainAction = WhatMainAction.Change;
                FormObjectFields.CreateObjectFields();
                FormObjectFields.ShowDialog();
                listBox.Items[selectedIndex] = Control.CurrObject;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                IFootball footballObject = listBox.SelectedItem as IFootball;
                Control.RemoveObject(footballObject);
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }
    }
}