using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    /*public string rase;
    public string clas;
    public int fiz_at = 0,
        fiz_def = 0,
        mag_at = 0,
        mag_def = 0,
        accuracy = 0,
        evasion = 0,
        speed = 0;
    public bool isMelee;
    */
    public int id;
    public string name;
    public string type;
    public bool isMelee;
    public int fiz_at = 0,
        fiz_def = 0,
        mag_at = 0,
        mag_def = 0,
        accuracy = 0,
        evasion = 0,
        speed = 0;
    public string description;
    void Start()
    {
        string path = "Assets/Items/Items.xml";
        XDocument xDoc = XDocument.Load(path);
        XElement root = xDoc.Element("Items");
        foreach (XElement xEle in root.Elements("id"))
        {
            id=Convert.ToInt32(xEle.Attribute("id").Value.Trim());
            name = xEle.Element("name").Value.Trim();
            type = xEle.Element("type").Value.Trim();
            fiz_at = Convert.ToInt32(xEle.Element("fiz_at").Value.Trim());
            fiz_def = Convert.ToInt32(xEle.Element("fiz_def").Value.Trim());
            mag_at = Convert.ToInt32(xEle.Element("mag_at").Value.Trim());
            mag_def = Convert.ToInt32(xEle.Element("mag_def").Value.Trim());
            accuracy = Convert.ToInt32(xEle.Element("accuracy").Value.Trim());
            evasion = Convert.ToInt32(xEle.Element("evasion").Value.Trim());
            speed = Convert.ToInt32(xEle.Element("speed").Value.Trim());
            isMelee = Convert.ToBoolean(xEle.Element("isMelee").Value.Trim());
            description = xEle.Element("description").Value.Trim();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
