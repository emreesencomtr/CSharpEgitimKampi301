using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.Project
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiTravelEfDbEntities db = new EgitimKampiTravelEfDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon Sayısı
            lblLocationCount.Text= db.Location.Count().ToString();
            #endregion
            #region Toplam Kapasite
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            #endregion
            #region Toplam Rehber Sayısı
            lblGuideCount.Text=db.Guide.Count().ToString();
            #endregion
            #region Toplam Kapasite
            lblAvgCapacity.Text = db.Location.Average(x=>x.Capacity).ToString();
            #endregion
            #region Ortalam Tur Fiyatı
            lblAvgLocationPrice.Text=db.Location.Average(x=>x.Price).Value.ToString("F2") + " ₺";
            #endregion
            #region En Son Ülkeyi Getirme
            int LastCountryId= db.Location.Max(x=> x.LocationId);
            lblLastCountryName.Text= db.Location.Where(x=> x.LocationId==LastCountryId).Select(y=>y.Country).FirstOrDefault();
            #endregion
            #region Kapadokya Tur Kapaasitesi
            lblCappodociaLocaitonCapacity.Text = db.Location.Where(x=> x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            #endregion
            #region Türkiye Turları Ortalama Kapasite
            lblTurkiyeCapacityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).Value.ToString("F2");
            #endregion
            #region Roma Gezi Rehberi
            var romeGuideId= db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName+" "+ y.GuideSurname).FirstOrDefault().ToString();
            #endregion
            #region En Yüksek Kapasiteli Tur
            var maxCapacity =db.Location.Max(x=>x.Capacity);
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
            #endregion
            #region En Pahalı Tur
            var maxPrice = db.Location.Max(x=>x.Price);
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();
            #endregion
            #region Emre Esen Tur Sayısı
            var guideIdByNameEmreEsen=db.Guide.Where(x=>x.GuideName=="Emre" && x.GuideSurname=="Esen").Select(y=>y.GuideId).FirstOrDefault();
            lblEmreEsen.Text = db.Location.Where(x => x.GuideId == guideIdByNameEmreEsen).Count().ToString();

            #endregion
        }
    }
}
