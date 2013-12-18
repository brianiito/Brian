using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSEvening
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal total = 0;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int qty = 0;
            if (cboItems.SelectedIndex == -1)
            {
                MessageBox.Show(" An item !");
                cboItems.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                try
                {
                   qty = int.Parse(txtQty.Text);
                   total = total + decimal.Parse((3.5 * qty) + "");
                   txtDue.Text = total.ToString();  
                }
                catch(Exception eex){
                    MessageBox.Show("Unacceptable Quantity " ,
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(eex.Message + " occurred in btnAddtoCart");
                    return;
                }
               
            }
            else if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Select the Quantity!");
                txtQty.Focus();
                return;
            }

            string item = cboItems.Text;
            decimal price = 3.5m;
            //int qty =0;
            //int.TryParse(txtQty.Text, out qty);
            decimal ExtPrice = price * qty;

            string[] cartline = {
                                     item, 
                                     price.ToString("F2"),
                                     qty.ToString(),
                                     ExtPrice.ToString("F2")
                                 };

            dgvCart.Rows.Add(cartline);
            ClearEntry();
        }

        private void ClearEntry()
        {
            cboItems.SelectedIndex = -1;
            txtQty.Text = "";
       
        
        }

         private void texDue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(txtQty.Text);
                string item = cboItems.Text;
                decimal price = 3.5m;
                decimal ExtPrice = price * qty;
            }
            catch (Exception xx)
            {
                MessageBox.Show("Invalid Entry");
            }
        }
        private void btnFinish_Click_1(object sender, EventArgs e)
        {
            
            decimal paid = decimal.Parse((txtPaid.Text) + "");
            if (paid >= total)
            {
                
                decimal change = paid - total;
                txtChange.Text = change.ToString();
                MessageBox.Show("Transaction successful!");
            }
            else
            {
               
                MessageBox.Show("Amount quoted is less than product cost");
            }
        }


        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}











