using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                         System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            string[] set1 = a.Split(',');
            string[] set2 = b.Split(',');
            float[] A, B;
            A = new float[set1.Length];
            B = new float[set2.Length];
            bool ok;
            for (int i = 0; i < set1.Length; i++)
            {
                ok = float.TryParse(set1[i], out A[i]);
                if (!ok)
                {
                    MessageBox.Show("Задано некоректну числову множину!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < set2.Length; i++)
            {
                ok = float.TryParse(set2[i], out B[i]);
                if (!ok)
                {
                    MessageBox.Show("Задано некоректну числову множину!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            float res;
            float[,] C = new float[A.Length, B.Length];
            dataGridViewMatrix.RowCount = A.Length;
            dataGridViewMatrix.ColumnCount = B.Length;
            for (int j = 0; j < A.Length; j++)
                dataGridViewMatrix.Rows[j].HeaderCell.Value = A[j].ToString();
            for (int i = 0; i < B.Length; i++)
            {
                dataGridViewMatrix.Columns[i].HeaderText = B[i].ToString();
                dataGridViewMatrix.Columns[i].Width = 40;
            }
            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    res = 3 * A[j] - B[i];
                    if (res < 1)
                    {
                        C[j, i] = 1;
                    }
                    else
                    {
                        C[j, i] = 0;
                    }
                }
            }
            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    dataGridViewMatrix.Rows[j].Cells[i].Value = Convert.ToString(C[j, i]);
                }
            }
        }
    }
}
