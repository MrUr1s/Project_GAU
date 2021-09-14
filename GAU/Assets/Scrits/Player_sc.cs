using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits
{
    public class Player_sc : action_cs
    {
        public Player_sc(IHaracteristisc.Race race, IHaracteristisc.Class clas, int fiz_at, int fiz_def, int mag_at, int mag_def,
            int accuracy, int evasion, int speed, int hp, int mp, bool isMelee) :
            base(race, clas, fiz_at, fiz_def, mag_at, mag_def, accuracy, evasion, speed, hp, mp, isMelee)
        {
        }

        void Start()
        {
            //Character character = new Character();
            //new Player_sc(
            //race = character.race,
            //clas = character.clas,
            //fiz_at = character.fiz_at,
            //fiz_def = character.fiz_def,
            //mag_at = character.mag_at,
            //mag_def = character.mag_def,
            //accuracy = character.accuracy,
            //evasion = character.evasion,
            //speed = character.speed,
            //isMelee = character.isMelee
            //);
        }

        void Update()
        {

        }
       
    }
}
