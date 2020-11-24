using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis_27_4_2018
{
    class Rezervacija
    {
        public static bool Rezervisano { get; set; }
        public static string NazivRezervacije { get; set; }
        public static string BrDokumenta { get; set; }
        public static string TipVozila { get; set; }
        public static DateTime VrijemeRezervacije { get; set; }

        public static string Mjesto { get; set; }


        public Rezervacija()
        {
            Rezervisano = false;
            NazivRezervacije = "";
            BrDokumenta = "";
            TipVozila = "";
            Mjesto = "";
            VrijemeRezervacije = DateTime.Now;
        }

        public static string Ispis()
        {
            return Mjesto + " - Dolazak" + Environment.NewLine + "Vozilo: " + TipVozila + Environment.NewLine+"Vrijeme: " + VrijemeRezervacije.ToString("HH:mm:ss")+Environment.NewLine+Environment.NewLine;
        }
    }
}
