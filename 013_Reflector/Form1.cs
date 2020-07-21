using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace _013_Reflector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog.FileName;
                    Assembly assembly = Assembly.LoadFile(path);
                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;

                    // Вывод информации о всех типах в сборке.
                    textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        textBox.Text += "Тип:  " + type + Environment.NewLine;
                        MethodInfo[] methods = type.GetMethods();

                        if (methods != null)
                        {
                            foreach (MethodInfo method in methods)
                            {
                                string methStr = "Метод:" + method.Name + "\n";
                                var methodBody = method.GetMethodBody();

                                if (methodBody != null)
                                {
                                    var byteArray = methodBody.GetILAsByteArray();

                                    foreach (var b in byteArray)
                                    {
                                        methStr += b + ":";
                                    }
                                }

                                textBox.Text += methStr + Environment.NewLine;
                            }
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
