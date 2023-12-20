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

namespace ProjektSortowanieV3
{
    public partial class Sort : Form
    {
        public Sort()
        {
            InitializeComponent();
            sortSelection.SelectedIndex = 0;
        }

        private void bubbleSortButton_Click(object sender, EventArgs e)
        {
            int n = (int)amountNumeric.Value;
            int i = 1;
            chart.ChartAreas.First().AxisX.Title = "Elements amount";
            chart.ChartAreas.First().AxisX.CustomLabels.Clear();

            chart.ChartAreas.First().AxisY.Title = "Time wasted by my computer";
            chart.ChartAreas.First().AxisY.LabelStyle.Format = "0ms";


            chart.Series.Clear();

            Series sBubble = new Series();
            sBubble.ChartType = SeriesChartType.Line;
            Program.Sort bs;
            for (int x = 1; x <= (int)seriesNumeric.Value; x++)
            {
                if (sortSelection.SelectedIndex == 0)
                {
                    bs = new Program.BubleSort(n);
                }
                else if (sortSelection.SelectedIndex == 1)
                {
                    bs = new Program.InsertionSort(n);
                }
                else if (sortSelection.SelectedIndex == 2)
                {
                    bs = new Program.SelectionSort(n);
                }
                else if (sortSelection.SelectedIndex == 3)
                {
                    bs = new Program.QuickSort(n);
                }
                else
                {
                    bs = new Program.MergeSort(n);
                }
                bs.SortData();
                DataPoint d = new DataPoint(i, bs.Duration);

                d.Label = (bs.Duration).ToString();
                d.MarkerStyle = MarkerStyle.Circle;
                d.MarkerSize = 10;
                d.MarkerColor = Color.Red;

                sBubble.Points.Add(d);

                //ustawienie labelków dla osi X
                chart.ChartAreas.First().AxisX.CustomLabels.Add(i - 0.5, i + 0.5, n.ToString());
                i++;

                n *= (int)multiplierNumeric.Value;

                //zabezpiecznie przed zbyt długim działaniem ... pierwsza seria powyżej 1000ms przerywa pętlę
                if (bs.Duration > 10000)
                {
                    break;
                }
            }

            chart.Series.Add(sBubble);

            //dopasowanie skali a osiach wykresu
            chart.ChartAreas.First().RecalculateAxesScale();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
