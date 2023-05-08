using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using anketproje.Models;
using anketproje.ViewModel;

namespace anketproje.Controllers
{
    public class ServisController : ApiController
    {
        DB01Entities db = new DB01Entities();
        SonucModel sonuc = new SonucModel();


        #region Soru

        [HttpGet]
        [Route("api/Soruliste")]

        public List<SoruModel> DersListe()
        {
            List<SoruModel> liste = db.Ders.Select(x => new SoruModel()
            {
                soruId = x.soruId,
                sorular = x.sorular,
                soruCevap = x.soruCevap,
                soruSayisi = x.soruSayisi
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/sorubyid/{dersId}")]

        public SoruModel soruById(string dersId)
        {
            SoruModel kayit = db.soru.Where(s => s.soruId == soruId).Select(x => new SoruModel()
            {
                soruId = x.soruId,
                sorular = x.sorular,
                soruCevap = x.soruCevap,
                soruSayisi = x.soruSayisi
            }).SingleOrDefault();

            return kayit;
        }

        [HttpPost]
        [Route("api/soruekle")]

        public SonucModel SoruEkle(SoruModel model)
        {
            if (db.Soru.Count(s => s.soru == model.soru) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Soru Kayıtlıdır!";
                return sonuc;
            }

            Soru yeni = new Soru();
            yeni.soruId = Guid.NewGuid().ToString();
            yeni.soru = model.soru;
            yeni.soruCevap = model.soruCevap;
            yeni.soruSayisi = model.soruSayisi;
            db.soru.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/soruduzenle")]

        public SonucModel SoruDuzenle(SoruModel model)
        {
            Soru kayit = db.soru.Where(s => s.soruId == model.soruId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Soru Bulunamadı!";
                return sonuc;
            }

            kayit.soru = model.soru;
            kayit.soruCevap = model.soruCevap;
            kayit.soruSayisi = model.soruSayisi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Soru Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/sorusil/{dersId}")]

        public SonucModel SoruSil(string dersId)
        {
            Soru kayit = db.Soru.Where(s => s.soruId == soruId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Soru Bulunamadı!";
                return sonuc;
            }

            if (db.Kayit.Count(s => s.kayitSoruId == soruId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Soru Kayıtlı Olduğu İçin Soru Silinemez!";
                return sonuc;
            }



            db.Soru.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Silindi";
            return sonuc;
        }

        #endregion

        #region Üye

        [HttpGet]
        [Route("api/üyeliste")]
        
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeNo = x.uyeNo,
                uyeAdsoyad = x.uyeAdsoyad,
                uyeKayitTarih = x.uyeKayitTarih,
            }).ToList();
            return liste;
        } 


        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]

        public UyeModel OgrenciById(string ogrId)
        {
            UyeModel kayit = db.Uye.Where(s=>s.uyeId==uyeId).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeNo = x.uyeNo,
                uyeAdsoyad = x.uyeAdsoyad,
                uyeKayitTarih = x.uyeKayitTarih,
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/üyeekle")]

        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s => s.uyeNo == model.uyeNo) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Üye Kayıtlıdır!";
            }

            Uye yeni = new Uye();
            yeni.uyeId = Guid.NewGuid().ToString();
            yeni.uyeNo = model.uyeNo;
            yeni.uyeAdsoyad = model.uyeAdsoyad;
            yeni.uyeKayitTarih = model.uyeKayitTarih;
            db.Uye.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/üyeduzenle")]

        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == model.uyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " Üye Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.uyeNo = model.uyeNo;
            kayit.uyeAdsoyad = model.uyeAdsoyad;
            kayit.uyeKayitTarih = model.uyeKayitTarih;

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/üyesil")]

        public SonucModel UyeSil(string ogrId)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == uyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Kayıt Bulunamadı!";
                return sonuc;
            }


            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";
            return sonuc;
        }




        #endregion


        #region Kayit

        [HttpGet]
        [Route("api/UyeSoruliste/{uyeId}")]

        public List<KayitModel> UyeSoruListe(string ogrId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitUyeId == uyeId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitSoruId = x.kayitSoruId,
                kayitUyeId = x.kayitUyeId,
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.uyeBilgi = UyeById(kayit.kayitUyeId);
                kayit.SoruBilgi = SoruById(kayit.kayitSoruId);

            }

            return liste;

        }


        [HttpGet]
        [Route("api/UyeSoruliste/{soruId}")]

        public List<KayitModel> UyeSoruliste(string uyeId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitUyeId == uyeId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitSoruId = x.kayitSoruId,
                kayitUyeId = x.kayitUyeId,
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.uyeBilgi = OgrenciById(kayit.kayitUyeId);
                kayit.soruBilgi = soruById(kayit.kayitSoruId);

            }

            return liste;

        }

        [HttpPost]
        [Route("api/kayitekle")]

        public SonucModel KayitEkle(KayitModel model)
        {
            if(db.Kayit.Count(s=>s.kayitSoruId==model.kayitSoruId && s.kayitUyeId == model.kayitUyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Önceden Kayıtlıdır!";
                return sonuc;
            }


            Kayit yeni = new Kayit();
            yeni.kayitId = Guid.NewGuid().ToString();
            yeni.kayitUyeId = model.kayitUyeId;
            yeni.kayitSoruId = model.kayitSoruId;
            db.Kayit.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Kaydı Eklendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kayitsil/{kayitId}")]


        public SonucModel KayitSil(string kayitId)
        {
            Kayit kayit = db.Kayit.Where(s => s.kayitId == kayitId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.Kayit.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Kaydı Silindi";
            return sonuc;
            }


        #endregion
    }
}
