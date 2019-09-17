using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System;

public class Hub : MonoBehaviour {

    public GameObject stat_panel;
    public GameObject[] stats;
    

    string rase, clas;
    int fiz_at,
        fiz_def,
        mag_at,
        mag_def,
        accuracy,
        evasion,
        speed;
    bool isMelee;

    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
	
	}
    public void stat()
    {
        stat_panel.SetActive(!stat_panel.activeSelf);

        stats[0].GetComponent<Text>().text = rase;
        stats[1].GetComponent<Text>().text = clas;
        stats[2].GetComponent<Text>().text = fiz_at.ToString();
        stats[3].GetComponent<Text>().text = fiz_def.ToString();
        stats[4].GetComponent<Text>().text = mag_at.ToString();
        stats[5].GetComponent<Text>().text = mag_def.ToString();
        stats[6].GetComponent<Text>().text = accuracy.ToString();
        stats[7].GetComponent<Text>().text = evasion.ToString();
        stats[8].GetComponent<Text>().text = speed.ToString();
        stats[9].GetComponent<Text>().text = isMelee.ToString();
    }
}
