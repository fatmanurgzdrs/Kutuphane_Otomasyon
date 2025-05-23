using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane047
{
    public partial class AdminSecimForm: Form
    {
        public AdminSecimForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void adminSecimBTN_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void idareciSecimBTN_Click(object sender, EventArgs e)
        {
            IdareciForm idareciForm = new IdareciForm();
            idareciForm.Show();
            this.Hide();
        }

        private void personelSecimBTN_Click(object sender, EventArgs e)
        {
            PersonelForm personelForm = new PersonelForm();
            personelForm.Show();
            this.Hide();
        }

        private void geriDonBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisEkrani form1 = new GirisEkrani();
            form1.Show();
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
