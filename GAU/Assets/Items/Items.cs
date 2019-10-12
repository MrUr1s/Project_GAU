using System;
using UnityEngine;
using System.Xml.Linq;

namespace Assets.Scrits
{
    class Items : MonoBehaviour
    {
        public int id;
        public string item_name;
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
        public bool Android = false;
      

        public void Start()
        {
            XDocument xDoc = XDocument.Load(Global.path);
            foreach (XElement xe in xDoc.Element("Items").Elements())
                if (xe.Attribute("id") != null)
                    if (id == Convert.ToInt32(xe.Attribute("id").Value))
                    {
                        item_name = xe.Element("name").Value;
                        type = xe.Element("type").Value;
                        fiz_at = Convert.ToInt32(xe.Element("fiz_at").Value);
                        fiz_def = Convert.ToInt32(xe.Element("fiz_def").Value);
                        mag_at = Convert.ToInt32(xe.Element("mag_at").Value);
                        mag_def = Convert.ToInt32(xe.Element("mag_def").Value);
                        accuracy = Convert.ToInt32(xe.Element("accuracy").Value);
                        evasion = Convert.ToInt32(xe.Element("evasion").Value);
                        speed = Convert.ToInt32(xe.Element("speed").Value);
                        isMelee = Convert.ToBoolean(xe.Element("isMelee").Value);
                        description = xe.Element("description").Value;
                    }
        }
       
    }
}

