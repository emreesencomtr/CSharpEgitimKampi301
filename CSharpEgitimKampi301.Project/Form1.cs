using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiTravelEfDbEntities db = new EgitimKampiTravelEfDbEntities();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtRehberAd.Text;
            guide.GuideSurname = txtRehberSoyad.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtRehberID.Text);
            var removeValue = db.Guide.Find(id);
            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtRehberID.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName = txtRehberAd.Text;
            updateValue.GuideSurname = txtRehberSoyad.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtRehberID.Text);
            var values = db.Guide.Where(x=> x.GuideId == id).ToList();
            dataGridView1.DataSource= values;   


        }
    }
}
