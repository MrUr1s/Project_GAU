using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;

public class Lang1 : MonoBehaviour {

    public TextAsset text_asset;
    public string lang;
    void Awake()
    {

    }

    public void Start()
    {
        lang = PlayerPrefs.GetString("Lang");
        Text txt_race = GetComponent<Text>();        
        XmlDocument xmld = new XmlDocument();
        xmld.LoadXml(text_asset.text);
        XmlElement xmle = xmld.DocumentElement;
        foreach (XmlNode xnode in xmle)        
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("lang");
                if (attr != null)
                    if (attr.Value == lang)                    
                        foreach (XmlNode child in xnode.ChildNodes)
                        {
                            if (txt_race.name == child.Attributes.Item(0).Value)
                                txt_race.text = child.Attributes.Item(1).Value;
                        }
                    
            }    
    }
}
