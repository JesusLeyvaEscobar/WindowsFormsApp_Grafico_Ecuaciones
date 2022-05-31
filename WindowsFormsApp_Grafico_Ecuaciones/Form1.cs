using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp_Grafico_Ecuaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicializarGrafico();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            textBoxDatos.Text = "";
            string cadena = textBoxFormula.Text;
            string[] tokens = cadena.Split(' ');
            //token[0] -> X
            //token[1] -> ^ 
            //token[2] -> n

            double riniX = -10.0;
            double y = 0.0;
            double pot = Convert.ToDouble(tokens[2]);
            int i;
            InicializarGrafico();
            for(i=1; i<=20; i++)
            {
                y = Math.Pow(riniX,pot);
                textBoxDatos.Text = textBoxDatos.Text + "     " + riniX.ToString() +
                   "     " + y.ToString() + Environment.NewLine;
                riniX += 1.0;
                this.chartA.Series["ValorY"].Points.AddXY(riniX, y);
            }
        }

        void InicializarGrafico()
        {
            this.chartA.Series.Clear();

            var serieAY = chartA.Series.Add("ValorY");
            serieAY.ChartType = SeriesChartType.Spline;
            serieAY.XValueType = ChartValueType.Single;
            chartA.Series["ValorY"].Color = Color.Red;
        }
    }
}
