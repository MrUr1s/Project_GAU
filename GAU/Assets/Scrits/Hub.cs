using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System;

namespace Assets.Scrits {
    public class Hub : MonoBehaviour {

        public GameObject stat_panel,item;
        public GameObject[] stats;
        Character character;
        public Sprite sprite,sp;

      

        void Awake()
        {
            character = new Character();
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update() {

        }
        public void stat()
        {
            stat_panel.SetActive(!stat_panel.activeSelf);

            stats[0].GetComponent<Text>().text = character.rase;
            stats[1].GetComponent<Text>().text = character.clas;
            stats[2].GetComponent<Text>().text = character.fiz_at.ToString();
            stats[3].GetComponent<Text>().text = character.fiz_def.ToString();
            stats[4].GetComponent<Text>().text = character.mag_at.ToString();
            stats[5].GetComponent<Text>().text = character.mag_def.ToString();
            stats[6].GetComponent<Text>().text = character.accuracy.ToString();
            stats[7].GetComponent<Text>().text = character.evasion.ToString();
            stats[8].GetComponent<Text>().text = character.speed.ToString();
            stats[9].GetComponent<Text>().text = character.isMelee.ToString();
        }
    }

}