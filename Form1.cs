/*
Вариант 15

В одномерном массиве, состоящем из п вещественных элементов, вычислить:
• количество элементов массива, больших С;
• произведение элементов массива, расположенных после максимального по модулю элемента.
Преобразовать массив таким образом, чтобы сначала располагались все отрицательные элементы, а потом — все положительные (элементы, равные нулю, считать положительными).
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace L4CS
{
    public partial class Form1 : Form
    {
        Random rand = new Random(); 
        List<int> matr = new List<int>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            matr.Clear();
            int n;
            try { n = Int32.Parse(textBox1.Text); }
            catch { MessageBox.Show("Неверный ввод!"); return; }
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++) dataGridView1.Columns[i].Name = "n" + i.ToString();
            dataGridView2.ColumnCount = n;
            for (int i = 0; i < n; i++) dataGridView2.Columns[i].Name = "n" + i.ToString();

            int temp;
            for(int i = 0; i < n; i++)
            {
                temp = rand.Next(-10, 10);
                matr.Add(temp);
                dataGridView1.Rows[0].Cells[i].Value = temp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int C;
            try { C = Int32.Parse(textBox2.Text); }
            catch { MessageBox.Show("Неверный ввод!"); return; }

            int count = 0;
            foreach (var item in matr) if (item > C) count++;
            label1.Text = "Кол-во элементов, больших С: " + count.ToString();

            int prod = 1;
            int ind = 0;
            if (matr.Max() > Math.Abs(matr.Min())) ind = matr.IndexOf(matr.Max()); else ind = matr.IndexOf(matr.Min());
            if (ind+1 == matr.Count()) { prod = 0; }
            else for (int i = ind+1; i < matr.Count(); i++ ) prod*=matr[i];
            label2.Text = "Произведение чисел, \r\nстоящих после большего по модулю: " + prod.ToString();

            count = 0;
            foreach (var item in matr)
                if (item < 0) {
                    dataGridView2.Rows[0].Cells[count].Value = item;
                    count++;
                }

            foreach (var item in matr)
                if (item >= 0)
                {
                    dataGridView2.Rows[0].Cells[count].Value = item;
                    count++;
                }
        }
    }
}
