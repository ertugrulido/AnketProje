using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anketproje.ViewModel
{
    public class KayitModel
    {
        public string kayitId { get; set; }
        public string kayitSoruId { get; set; }
        public string kayitUyeId { get; set; }

        public UyeModel uyeBilgi { get; set; }

        public SoruModel soruBilgi { get; set; }
    }
}