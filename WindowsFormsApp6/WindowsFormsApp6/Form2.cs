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
    public partial class Form2 : Form
    {
        public string s1;
        public string s2;
        public string s3;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.testDataSet.Tables[0].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = tbName.Text;
                nRow[2] = tbPhone.Text;
                nRow[3] = tbMail.Text;

                main.testDataSet.Tables[0].Rows.Add(nRow);
                main.contactsTableAdapter.Update(main.testDataSet.contacts);
                main.testDataSet.Tables[0].AcceptChanges();
                main.dataGridView1.Refresh();
                tbName.Text = "";
                tbPhone.Text = "";
                tbMail.Text = "";

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbName.Text = s1;
            tbPhone.Text = s2;
            tbMail.Text = s3;
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
