using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits
{
    public class Player_sc : MonoBehaviour
    {
        public string rase = "";
        public string clas = "";
        public int fiz_at = 0,
            fiz_def = 0,
            mag_at = 0,
            mag_def = 0,
            accuracy = 0,
            evasion = 0,
            speed = 0;
        public bool isMelee = false;
        void Start()
        {
            Character character = new Character();
            rase = character.rase;
            clas = character.clas;
            fiz_at = character.fiz_at;
            fiz_def = character.fiz_def;
            mag_at = character.mag_at;
            mag_def = character.mag_def;
            accuracy = character.accuracy;
            evasion = character.evasion;
            speed = character.speed;
            isMelee = character.isMelee;
    }

        void Update()
        {

        }
    }
}