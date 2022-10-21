using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueens
{
    public partial class Form1 : Form
    {
        private int N;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            
        }

        bool IsStrike(int x1, int y1, int x2, int y2)
        {
            if ((x1 == x2) || (y1 == y2)) return true;

            int tx, ty;

            tx = x1 - 1; ty = y1 - 1;
            while ((tx >= 1) && (ty == y2)) return true;
            {
                if ((tx == x2) && (ty == y2)) return true;
                tx--; ty--;
            }
            

            tx = x1 + 1; ty = y1 + 1;
            while ((tx <= N) && (ty <= N))
            {
                if ((tx == x2) && (ty == y2)) return true;
                tx++; ty++;
            }

            tx = x1 + 1; ty = y1 - 1;
            while ((tx <= N) && (ty >= 1))
            {
                if ((tx == x2) && (ty == y2)) return true;
                tx++; ty--;
            }

            tx = x1 - 1; ty = y1 + 1;
            while ((tx >= 1) && (ty <= N))
            {
                if ((tx == x2) && (ty == y2)) return true;
                tx--; ty++;
            }
            return false;
        }

        bool Strike(int[] M, int p)
        {
            int px, py, x, y;
            int i;

            px = M[p];
            py = p;

            for (i = 1; i <= p - 1; i++)
            {
                x = M[i];
                y = i;
                if (IsStrike(x, y, px, py))
                    return true;
            }
            return false;
        }

        void InitDataGriView(int N)
        {
            int i;

            dataGridView1.Columns.Clear();

            for (i = 1; i <= N; i++)
            {
                dataGridView1.Columns.Add("i" + i.ToString(), i.ToString());

                dataGridView1.Columns[i - 1].Width = 30;
            }

            dataGridView1.Rows.Add(N);

            for (i = 1; i <= N; i++)
                dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        void ShowDataGridView(string s, int N)
        {
            int i;
            int j;
            string xs, ys;
            int x, y;

            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    dataGridView1.Rows[i].Cells[j].Value = "";

            j = 0;
            for (i = 0; i < N; i++)
            {
                xs = "";
                while (s[j] != ',')
                {
                    xs = xs + s[j].ToString();
                    j++;
                }

                j++;

                ys = "";
                while (s[j] != '-')
                {
                    ys = ys + s[j].ToString();
                    j++;
                }

                j++;

                x = Convert.ToInt32(xs);
                y = Convert.ToInt32(ys);

                dataGridView1.Rows[y - 1].Cells[x - 1].Value = "X";
            }
        }

        void AddToListBox(int[] M, int N)
        {
            string s = "";
            for (int i = 1; i <= N; i++)
                s = s + M[i].ToString() + "," + i.ToString() + "-";
            listBox1.Items.Add(s);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0) return;
            int num;
            string s;
            num = listBox1.SelectedIndex;
            s = listBox1.Items[num].ToString();
            ShowDataGridView(s, N);
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Count <= 0) return;
            int num;
            string s;
            num = listBox1.SelectedIndex;
            s = listBox1.Items[num].ToString();
            ShowDataGridView(s, N);
        }

        private void button1_Click(object sender, KeyEventArgs e)
        {
            const int MaxN = 20;
            int[] M = new int[MaxN];
            int p;
            int k;

            N = Convert.ToInt32(textBox1.Text);

            InitDataGriView(N);

            listBox1.Items.Clear();

            p = 1;
            M[p] = 0;
            M[0] = 0;
            k = 0;

            while (p > 0)
            {
                M[p] = M[p] + 1;
                if (p == N)
                {
                    if (M[p] > N)
                    {
                        while (M[p] > N) p--;
                    }
                    else
                    {
                        if (M[p] > N)
                        {
                            while (M[p] > N) p--;
                        }
                        else 
                        {
                            if (!Strike(M, p))
                            {
                                p++;
                                M[p] = 0;
                            }
                        }
                    }

                }
                if (k > 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1_Click(sender, e);
                    label2.Text = "Number of placements =" + k.ToString();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int MaxN = 20;
            int[] M = new int[MaxN];
            int p;
            int k;

            N = Convert.ToInt32(textBox1.Text);

            InitDataGriView(N);

            listBox1.Items.Clear();

            p = 1;
            M[p] = 0;
            M[0] = 0;
            k = 0;

            while (p > 0)
            {
                M[p] = M[p] + 1;
                if (p == N)
                {
                    if (M[p] > N)
                    {
                        while (M[p] > N) p--;
                    }
                    else
                    {
                        if (M[p] > N)
                        {
                            while (M[p] > N) p--;
                        }
                        else
                        {
                            if (!Strike(M, p))
                            {
                                p++;
                                M[p] = 0;
                            }
                        }
                    }

                }
                if (k > 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1_Click(sender, e);
                    label2.Text = "Number of placements =" + k.ToString();
                }
            }
        }
    }
}
