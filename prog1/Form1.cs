using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

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
            int limiter = 0;
            if ((Convert.ToInt32(BoxKN.Text) + Convert.ToInt32(BoxNP.Text)) > 10000 ) { limiter = Convert.ToInt32(BoxKN.Text) + Convert.ToInt32(BoxNP.Text) - 10000; }
            int kn = Convert.ToInt32(BoxKN.Text) - limiter;
            for (int i = 0; i < kn; i++)
            {
                int a = Convert.ToInt32(BoxNP.Text);
                dataGridView1.Rows.Add((a+kn-1)-i, 0);
            }
            knd = kn;
            int rows = dataGridView1.RowCount;
            
            if (rows > 0) 
            {
                printB.Enabled = true;
            }

        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            
            printDocument1.PrinterSettings.Copies = Convert.ToInt16(ncopies.Value);
            printDocument1.PrinterSettings.Collate = false;
            printDocument1.PrinterSettings.PrinterName = listBox1.SelectedItem.ToString();
            counter = 0;
            curPage = 1;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
                  1, 30, new StringFormat());
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

            
            
            printDocument1.Print();
        }

        

        private void printDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.PaperSize = new PaperSize("Сustom", 228, 150);
            pageSetupDialog1.PageSettings.Margins = new Margins(0, 0, 0, 0);
         
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

        private void listBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void FormNofS_Load(object sender, EventArgs e)
        {
            
            printB.Enabled = false;
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
    
            for (int i = 0; i < sc.Count; i++)
            {
                printDocument1.PrinterSettings.PrinterName = sc[i];
                
                if (printDocument1.PrinterSettings.IsValid == true)
                {
                    listBox1.Items.Add(sc[i]);
                }
                listBox1.SelectedIndex = 0;
            }
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int rows = dataGridView1.RowCount;
            
            if (rows == 0) 
            {
                printB.Enabled = false;
            }
        }
    }
}
