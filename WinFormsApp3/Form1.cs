using System.Collections;
using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process programProcess = new Process();
            Hashtable openWith = new Hashtable
            {
                { "Notepad", "notepad.exe" },
                { "Calculator", "calc.exe" },
            };
            string text = listBox1.Text;
            string path = (string)openWith[text];
            programProcess.StartInfo = new ProcessStartInfo(path);
            try
            {
                programProcess.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завершенні процесу: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBox2.Items.Add(text);
            listBox1.Items.Remove(text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = listBox2.Text;
            Hashtable openWith = new Hashtable
            {
                { "Notepad", "notepad" },
                { "Calculator", "CalculatorApp" },
            };
            string path = (string)openWith[text];
            try
            {
                Process[] processes = Process.GetProcessesByName(path);
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завершенні процесу: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBox1.Items.Add(text);
            listBox2.Items.Remove(text);
        }
    }
}