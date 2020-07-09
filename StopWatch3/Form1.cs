using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StopWatch3
{
    public partial class Form1 : Form
    {
        private Stopwatch stopWatch;
        private TimeSpan ts;

        public Form1()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            textBox.Text = ts.ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            stopWatch.Restart();
            textBox.Text = "";
        }
    }
}
