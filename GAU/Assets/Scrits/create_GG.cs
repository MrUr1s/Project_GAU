using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;

public class create_GG : MonoBehaviour {

    public GameObject[] panel, characters;
    public GameObject sphere, particle;
    string race="Orc", clas= "Berserk";
    void Start () {
    }
	
	// Update is called once per frame
	void select_ch (string race) {
        for (int y = 0; y < characters.Length; y++)
            if (characters[y].name != race)
                characters[y].SetActive(false);
            else
                characters[y].SetActive(true);
        
    }
    public void SelectRase(string race)
    {
        this.race = race;
        select_ch(race);
        switch (race)
        {
            case "Orc":
                sphere.GetComponent<Renderer>().material.color = Color.green;                
                break;

            case "Human":
                sphere.GetComponent<Renderer>().material.color = Color.yellow;
                 break;

            case "Elf":
                sphere.GetComponent<Renderer>().material.color = Color.blue;
                 break;

            case "Robot":
                sphere.GetComponent<Renderer>().material.color = Color.grey;
                 break;

            default:
                break;
        }
    }
    public void SelectClass(string clas)
    {
        this.clas = clas;
        particle.SetActive(false);        
        switch (clas)
        {
            case "Berserk":
                particle.GetComponent<ParticleSystem>().startColor = Color.red;
                break;

            case "Sorcerer":
                particle.GetComponent<ParticleSystem>().startColor = Color.yellow;
                break;

            case "Gunslinger":
                particle.GetComponent<ParticleSystem>().startColor = Color.blue;
                break;

            case "Spiritmaster":
                particle.GetComponent<ParticleSystem>().startColor = Color.green;
                break;

            default:
                break;
        }
        particle.SetActive(true);
    }
    public void Next(int i1)
    {
        if (i1 != 1)
        {
            panel[i1].SetActive(false);
            panel[i1 + 1].SetActive(true);
        }
        else
        {
            Application.LoadLevel(2);
            Assets.Scrits.Global.character = new Assets.Scrits.Character(race, clas);
            

        }
    }
    public void Back(int i1)
    {
        if (i1 != 0)
        {
            panel[i1].SetActive(false);
            panel[i1 - 1].SetActive(true);
        }else
            Application.LoadLevel(0);
    }

}
