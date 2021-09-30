using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Click Data";
            btn.Text = "Редактировать";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;



            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.contacts". При необходимости она может быть перемещена или удалена.
            this.contactsTableAdapter.Fill(this.testDataSet.contacts);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            contactsTableAdapter.Update(testDataSet);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Owner = this;
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Owner = this;
            sf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    int index = dataGridView1.CurrentRow.Index;
                    Form2 sf = new Form2();
                    sf.s1= (string)dataGridView1.Rows[index].Cells[1].Value;
                    sf.s2 = Convert.ToString (dataGridView1.Rows[index].Cells[2].Value);
                    sf.s3 = (string)dataGridView1.Rows[index].Cells[3].Value;
                    sf.Owner = this;
                    sf.Show();
                }
            }
        }
    }
}

