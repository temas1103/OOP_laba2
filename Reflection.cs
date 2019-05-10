using System;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using FieldNameAtrributes;
using FootballLibrary;

namespace WindowsFormsApp1
{
    public class Reflection
    {
        public string GetFieldName(MemberInfo member)
        {
            Attribute attribute = member.GetCustomAttribute(typeof(FieldNameAtrribute));
            if (attribute is FieldNameAtrribute fieldNameAtrribute)
                return fieldNameAtrribute.FieldName;
            else
                return null;
        }

        public string[] GetEnumNames(Type enumType)
        {
            FieldInfo[] fieldInfos = enumType.GetFields();
            string[] enumNames = { };
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                string enumName = GetFieldName(fieldInfo);
                if (enumName != null)
                {
                    Array.Resize(ref enumNames, enumNames.Length + 1);
                    enumNames[enumNames.Length - 1] = GetFieldName(fieldInfo);
                }
            }
            return enumNames;
        }

        public bool IsGenericParameter(Type propertyType, Type objectType)
        {
            foreach (var property in propertyType.GetProperties())
            {
                if (property.PropertyType.IsGenericType)
                {
                    Type[] genericArguments = property.PropertyType.GetGenericArguments();
                    if (Array.IndexOf(genericArguments, objectType) != -1)
                        return true;
                }
            }
            return false;
        }

        public void CreateFormFields(FormComposition form, object currObject)
        {
            const int LabelWidth = 100;
            const int LabelMarginLeft = 0;
            const int TextBoxAndComboBoxWidth = 140;
            const int TextBoxAndComboBoxMarginLeft = 100;
            const int MarginStep = 30;
            const int FormMarginTop = 70;
            int marginTop = 0;

            foreach (var property in currObject.GetType().GetProperties())
            {
                string propertyName = GetFieldName(property);
                Type propertyType = property.PropertyType;

                form.Controls.Add(CreateLabel(propertyName, LabelWidth, LabelMarginLeft, marginTop));

                if ((propertyType == typeof(string)) || (propertyType == typeof(int)))
                {
                    TextBox textBox = CreateTextBox(propertyName, TextBoxAndComboBoxWidth,
                                                        TextBoxAndComboBoxMarginLeft, marginTop);
                    if (propertyType == typeof(string))
                        textBox.Text = (string)property.GetValue(currObject) ?? "";
                    else
                        textBox.Text = (int)property.GetValue(currObject) != 0 ?
                                            property.GetValue(currObject).ToString() : "";
                    form.Controls.Add(textBox);
                }
                else if (propertyType.IsEnum)
                {
                    ComboBox comboBox = CreateComboBox(propertyName, TextBoxAndComboBoxWidth,
                                                           TextBoxAndComboBoxMarginLeft, marginTop);
                    comboBox.Items.Add("");
                    foreach (var enumName in GetEnumNames(property.PropertyType))
                    {
                        comboBox.Items.Add(enumName);
                    }
                    comboBox.SelectedIndex = (int)property.GetValue(currObject);
                    form.Controls.Add(comboBox);
                }
                marginTop += MarginStep;
            }
            Button buttonOk = form.Controls["ButtonOk"] as Button;
            Button buttonCansel = form.Controls["ButtonCancel"] as Button;
            buttonOk.Location = new Point(buttonOk.Location.X, marginTop);
            buttonCansel.Location = new Point(buttonCansel.Location.X, marginTop);
            form.Height = marginTop + FormMarginTop;
        }

        public void CreateFormFields(FormObjectFields form, Control control)
        {
            const int LabelWidth = 100;
            const int LabelMarginLeft = 0;
            const int TextBoxAndComboBoxWidth = 140;
            const int TextBoxAndComboBoxMarginLeft = 100;
            const int MarginStep = 30;
            const int FormMarginTop = 70;
            int marginTop = 0;
            IFootball currObject = control.CurrObject;

            foreach (var property in currObject.GetType().GetProperties())
            {
                string propertyName = GetFieldName(property);
                Type propertyType = property.PropertyType;

                form.Controls.Add(CreateLabel(propertyName, LabelWidth, LabelMarginLeft, marginTop));

                if ((propertyType == typeof(string)) || (propertyType == typeof(int)))
                {
                    TextBox textBox = CreateTextBox(propertyName, TextBoxAndComboBoxWidth,
                                                        TextBoxAndComboBoxMarginLeft, marginTop);
                    if (propertyType == typeof(string))
                        textBox.Text = (string)property.GetValue(currObject) ?? "";
                    else
                        textBox.Text = (int)property.GetValue(currObject) != 0 ?
                                            property.GetValue(currObject).ToString() : "";
                    form.Controls.Add(textBox);
                }
                else if (propertyType.IsEnum)
                {
                    ComboBox comboBox = CreateComboBox(propertyName, TextBoxAndComboBoxWidth,
                                                           TextBoxAndComboBoxMarginLeft, marginTop);
                    comboBox.Items.Add("");
                    foreach (var enumName in GetEnumNames(property.PropertyType))
                    {
                        comboBox.Items.Add(enumName);
                    }
                    comboBox.SelectedIndex = (int)property.GetValue(currObject);
                    form.Controls.Add(comboBox);
                }
                else if (propertyType.IsClass)
                {
                    if (propertyType.IsGenericType)
                    {
                        ComboBox comboBox = CreateComboBox(propertyName, TextBoxAndComboBoxWidth,
                                                               TextBoxAndComboBoxMarginLeft, marginTop);
                        var listObjects = property.GetValue(currObject) as IList;
                        foreach (var football in listObjects)
                        {
                            comboBox.Items.Add(football);
                        }
                        form.Controls.Add(comboBox);
                    }
                    else
                    {
                        bool genericParameter = IsGenericParameter(property.PropertyType, currObject.GetType());
                        if (genericParameter)
                        {
                            ComboBox comboBox = CreateComboBox(propertyName, TextBoxAndComboBoxWidth,
                                                                   TextBoxAndComboBoxMarginLeft, marginTop);
                            foreach (var applicationObject in control.ApplicationObjects)
                            {
                                if (applicationObject.GetType() == property.PropertyType)
                                    comboBox.Items.Add(applicationObject);
                            }
                            comboBox.SelectedItem = property.GetValue(currObject);
                            form.Controls.Add(comboBox);
                        }
                        else
                        {
                            Button buttonComposition = form.Controls["buttonComposition"] as Button;
                            buttonComposition.Location = new Point(buttonComposition.Location.X, marginTop);
                            buttonComposition.Visible = true;
                            control.CompositionObject = property.GetValue(currObject);
                        }
                    }
                }
                marginTop += MarginStep;
            }
            Button buttonOk = form.Controls["ButtonOk"] as Button;
            Button buttonCansel = form.Controls["ButtonCancel"] as Button;
            buttonOk.Location = new Point(buttonOk.Location.X, marginTop);
            buttonCansel.Location = new Point(buttonCansel.Location.X, marginTop);
            form.Height = marginTop + FormMarginTop;
        }

        public void SetPropertyValues(Form form, object currObject)
        {
            foreach (var property in currObject.GetType().GetProperties())
            {
                string propertyName = GetFieldName(property);
                Type propertyType = property.PropertyType;

                if ((propertyType == typeof(string)) || (propertyType == typeof(int)))
                {
                    TextBox textBox = form.Controls[propertyName] as TextBox;
                    if (propertyType == typeof(string))
                        property.SetValue(currObject, textBox.Text);
                    else
                        property.SetValue(currObject, int.Parse(textBox.Text));
                }
                else if ((propertyType.IsEnum || propertyType.IsClass) && !propertyType.IsGenericType)
                {
                    if (form.Controls[propertyName] is ComboBox comboBox)
                    {
                        if (propertyType.IsEnum)
                        {
                            if (comboBox.SelectedIndex > 0)
                                property.SetValue(currObject, comboBox.SelectedIndex);
                        }
                        else
                        {
                            if (comboBox.SelectedItem != null)
                                property.SetValue(currObject, comboBox.SelectedItem);
                        }
                    }
                }
            }
        }

        public Label CreateLabel(string text, int width, int marginLeft, int marginBottom)
        {
            return new Label
            {
                Width = width,
                Text = text,
                Location = new Point(marginLeft, marginBottom)
            };
        }

        public TextBox CreateTextBox(string name, int width, int marginLeft, int marginBottom)
        {
            return new TextBox
            {
                Name = name,
                Width = width,
                Location = new Point(marginLeft, marginBottom)
            };
        }

        public ComboBox CreateComboBox(string name, int width, int marginLeft, int marginBottom)
        {
            return new ComboBox
            {
                Name = name,
                Width = width,
                Location = new Point(marginLeft, marginBottom)
            };
        }
    }
}