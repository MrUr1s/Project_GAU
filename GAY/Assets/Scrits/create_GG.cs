using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;


public class create_GG : MonoBehaviour {

    public GameObject[] panel;
    public GameObject sphere, particle;
    public GameObject[] character;
    void Update () {
        
    }
	
	// Update is called once per frame
	void select_ch (int i) {
        for (int y = 0; y < character.Length; y++)
            if (y != i)
                character[y].SetActive(false);
            else
                character[y].SetActive(true);
        
    }
    public void SelectRase(int i)
    {
        select_ch(i);
        switch (i)
        {
            case 0:
                sphere.GetComponent<Renderer>().material.color = Color.green;                
                break;

            case 1:
                sphere.GetComponent<Renderer>().material.color = Color.yellow;
                 break;

            case 2:
                sphere.GetComponent<Renderer>().material.color = Color.blue;
                 break;

            case 3:
                sphere.GetComponent<Renderer>().material.color = Color.grey;
                 break;

            default:
                break;
        }
    }
    public void SelectClass(int i)
    {
        particle.SetActive(false);        
        switch (i)
        {
            case 0:
                particle.GetComponent<ParticleSystem>().startColor = Color.red;
                break;

            case 1:
                particle.GetComponent<ParticleSystem>().startColor = Color.yellow;
                break;

            case 2:
                particle.GetComponent<ParticleSystem>().startColor = Color.blue;
                break;

            case 3:
                particle.GetComponent<ParticleSystem>().startColor = Color.green;
                break;

            default:
                break;
        }
        particle.SetActive(true);
    }
    public void Next(int i1)
    {
        panel[i1].SetActive(false);
        panel[i1 + 1].SetActive(true);
    }
    public void Back(int i1)
    {
        panel[i1].SetActive(false);
        panel[i1-1].SetActive(true);
    }
    public void create()
    {

    }
}
