using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    public GameObject panel_lang, panel_option,panel_exit;
    public Lang lg;
    void Awake()
    {
        if (PlayerPrefs.GetString("Lang") == null)
        {
            panel_lang.SetActive(true);
        }
    }
	void Start () {
        if (PlayerPrefs.GetInt("option") == 1)
            panel_option.SetActive(true);
        else if (PlayerPrefs.GetInt("option") == 0)
            panel_option.SetActive(false);
        PlayerPrefs.DeleteKey("option");       
        
    }
	
	void Update () {
    }

    public void selectLang(string lang)
    {
        PlayerPrefs.SetString("Lang", lang);
        PlayerPrefs.Save();
        if(panel_option.activeSelf)
            PlayerPrefs.SetInt("option", 1);
        else
            PlayerPrefs.SetInt("option", 0);
        PlayerPrefs.Save();
        Application.LoadLevel(0);
    }
    public void New_Game()
    {
        Application.LoadLevel(1);
    }
    public void Continue()
    {
        Application.LoadLevel(2);
    }
    public void panel(string name)
    {
        if (name == "Exit")
            if (panel_exit.activeSelf)
                panel_exit.SetActive(false);
            else
                panel_exit.SetActive(true);
        else if (name == "Option")
            if (panel_option.activeSelf)
                panel_option.SetActive(false);
            else
                panel_option.SetActive(true);
        else if (name == "Lang")
            if (panel_lang.activeSelf)
                panel_lang.SetActive(false);
            else
                panel_lang.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    } 


}
