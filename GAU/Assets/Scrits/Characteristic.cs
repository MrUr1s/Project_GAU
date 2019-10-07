using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scrits
{
    public class Characteristic : MonoBehaviour
    {
        public GameObject[] characteristics;
        Character character;

        void Start()
        {
            character = new Character();
            characteristics[0].GetComponent<Text>().text = character.rase;
            characteristics[1].GetComponent<Text>().text = character.clas;
            characteristics[2].GetComponent<Text>().text = character.fiz_at.ToString();
            characteristics[3].GetComponent<Text>().text = character.fiz_def.ToString();
            characteristics[4].GetComponent<Text>().text = character.mag_at.ToString();
            characteristics[5].GetComponent<Text>().text = character.mag_def.ToString();
            characteristics[6].GetComponent<Text>().text = character.accuracy.ToString();
            characteristics[7].GetComponent<Text>().text = character.evasion.ToString();
            characteristics[8].GetComponent<Text>().text = character.speed.ToString();
            characteristics[9].GetComponent<Text>().text = character.isMelee.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
