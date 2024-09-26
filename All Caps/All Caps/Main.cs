
namespace All_Caps
{
    public partial class Form1 : Form


    {
        ProductForm prodfrm = new ProductForm();
        Sales salesfrm = new Sales();
        ExpensesFrm expensesfrm = new ExpensesFrm();
        InventoryFrm inventoryfrm = new InventoryFrm();
        SalesFrm salesdata = new SalesFrm();

        public Form1()
        {
            InitializeComponent();


        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            salesfrm.TopLevel = false;
            salesfrm.AutoScroll = true;
            panel1.Controls.Add(salesfrm);
            prodfrm.Hide();
            expensesfrm.Hide();
            inventoryfrm.Hide();
            salesdata.Hide();
            salesfrm.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            prodfrm.TopLevel = false;
            prodfrm.AutoScroll = true;
            panel1.Controls.Add(prodfrm);
            prodfrm.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            prodfrm.TopLevel = false;
            prodfrm.AutoScroll = true;
            panel1.Controls.Add(prodfrm);
            salesfrm.Hide();
            expensesfrm.Hide();
            inventoryfrm.Hide();
            salesdata.Hide();
            prodfrm.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            expensesfrm.TopLevel = false;
            expensesfrm.AutoScroll = true;
            panel1.Controls.Add(expensesfrm);
            salesfrm.Hide();
            prodfrm.Hide();
            inventoryfrm.Hide();
            salesdata.Hide();
            expensesfrm.Show();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            inventoryfrm.TopLevel = false;
            inventoryfrm.AutoScroll = true;
            panel1.Controls.Add(inventoryfrm);
            salesfrm.Hide();
            prodfrm.Hide();
            expensesfrm.Hide();
            salesdata.Hide();
            inventoryfrm.Show();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            salesdata.TopLevel = false;
            salesdata.AutoScroll = true;
            panel1.Controls.Add(salesdata);
            salesfrm.Hide();
            prodfrm.Hide();
            expensesfrm.Hide();
            inventoryfrm.Hide();
            salesdata.Show();
        }
    }
}
    
