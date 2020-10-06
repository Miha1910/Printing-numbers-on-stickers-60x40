using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog1
{

    public partial class FormNofS : Form
    {
        int knd = 0;
        int counter = 0; 
        int curPage;

        public FormNofS()
        {
            InitializeComponent();
            
        }
   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreatNB_Click(object sender, EventArgs e)
        {

            if (BoxKN.Text == "") { BoxKN.Text = "0"; }
            if (BoxNP.Text == "") { BoxNP.Text = "0"; }
            for (int id = knd; id >= 1; id--)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            int kn = Convert.ToInt32(BoxKN.Text);
            for (int i = 0; i < kn; i++)
            {
                int a = Convert.ToInt32(BoxNP.Text);
                dataGridView1.Rows.Add((a+kn-1)-i, 0);
            }
            knd = kn;
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter = 0;
            curPage = 1;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = dataGridView1.RowTemplate.DefaultCellStyle.Font;
            String curLine;
            int nPages = Convert.ToInt32(BoxKN.Text);
            int nLines = 1;
            int i;
            i = 0;
            while ((i < nLines) && (counter < dataGridView1.RowCount))
            {
                curLine = Convert.ToString(dataGridView1[0, counter].Value);
                e.Graphics.DrawString(curLine, myFont, Brushes.Black,
                  5, 30, new StringFormat());
                counter++;
                i++;
            }
            e.HasMorePages = false;
            if (curPage < nPages)
            {
                curPage++;
                e.HasMorePages = true;
            }
    
        }

        private void printB_Click(object sender, EventArgs e)
        {

            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Сustom", 228, 150);
            pageSetupDialog1.PageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        }

        private void BoxKN_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoxNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }

        private void BoxKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }
    }
}
