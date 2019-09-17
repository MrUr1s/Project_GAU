using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scrits
{
    class Character
    {
        string rase;
        string clas;
        int fiz_at, fiz_def, mag_at, mag_def, accuracy, evasion;

        public Character(string rase,string clas,int fiz_at, int fiz_def, int mag_at, int mag_def, int accuracy, int evasion)
        {
            this.evasion = evasion;
            this.accuracy = accuracy;
            this.mag_def = mag_def;
            this.mag_at = mag_at;
            this.fiz_def = fiz_def;
            this.fiz_at = fiz_at;
            this.clas = clas;
            this.rase = rase;
        }

        void add_characteristic(string characteristic, int add)
        {
            switch(characteristic)
            {
                case "fiz_at":
                    fiz_at += add;
                    break;
                case "fiz_def":
                    fiz_def += add;
                    break;
                case "mag_at":
                    mag_at += add;
                    break;
                case "mag_def":
                    mag_def += add;
                    break;
                case "accuracy":
                    accuracy += add;
                    break;
                case "evasion":
                    evasion += add;
                    break;
            }            
        }
    }
}
