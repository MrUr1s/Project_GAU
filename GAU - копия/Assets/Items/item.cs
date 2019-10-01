using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scrits
{
    class item: MonoBehaviour
    {
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

        public item(int id, string name, string type, bool isMelee, int fiz_at, int fiz_def, int mag_at, int mag_def, int accuracy, int evasion, int speed, string description)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.isMelee = isMelee;
            this.fiz_at = fiz_at;
            this.fiz_def = fiz_def;
            this.mag_at = mag_at;
            this.mag_def = mag_def;
            this.accuracy = accuracy;
            this.evasion = evasion;
            this.speed = speed;
            this.description = description;
        }
    }
}

/*
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
 */
