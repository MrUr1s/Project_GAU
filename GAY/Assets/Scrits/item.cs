using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scrits
{
    class item
    {
        public string name;
        public bool isMelee;
        public int fiz_at = 0,
            fiz_def = 0,
            mag_at = 0,
            mag_def = 0,
            accuracy = 0,
            evasion = 0,
            speed = 0;

        public item (string name, bool isMelee, int fiz_at, int fiz_def, int mag_at, int mag_def, int accuracy, int evasion,int speed)
        {
            this.name = name;
            this.isMelee = isMelee;
            this.fiz_at = fiz_at;
            this.fiz_def = fiz_def;
            this.mag_at = mag_at;
            this.mag_def = mag_def;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.speed = speed;
        }
    }
}
