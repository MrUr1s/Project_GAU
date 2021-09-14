using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scrits
{
    public class Enemy : action_cs
    {
  
        public int id = -1;
        public GameObject item;
        public int count = 0;

        public Enemy(IHaracteristisc.Race race, IHaracteristisc.Class clas, int fiz_at, int fiz_def, int mag_at, int mag_def,
            int accuracy, int evasion, int speed, int hp, int mp, bool isMelee) :
            base(race, clas, fiz_at, fiz_def, mag_at, mag_def, accuracy, evasion, speed, hp, mp, isMelee)
        {
        }

        void Start()
        {
            if (id == -1)
                id = Random.Range(1000000, 2000000);
        }

        void OnDestroy()
        {
            for (int i = 0; i < count; i++)
            {
                item.GetComponent<Assets.Scrits.Items>();
                Instantiate(item, GetComponentInParent<RectTransform>());
            }
        }

    }
}