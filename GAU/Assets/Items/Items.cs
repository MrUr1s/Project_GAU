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
            foreach (XElement xe in xDoc.Element("Items").Elements("item"))
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

        public void Save(int id_item=-1)
        {/*
            XmlDocument xmld = new XmlDocument();
            xmld.LoadXml(items_xml.text);
            XmlElement xmle = xmld.DocumentElement;
            foreach (XmlNode xnode in xmle)
                if (xnode.Attributes.Count > 0 && xnode.Attributes.GetNamedItem("Items") != null)
                    if (id == Convert.ToInt32(xnode.Attributes.GetNamedItem("Items").Value))
                    {
                        item_name = xnode["name"].InnerText.Trim();
                        type = xnode["type"].InnerText.Trim();
                        fiz_at = Convert.ToInt32(xnode["fiz_at"].InnerText.Trim());
                        fiz_def = Convert.ToInt32(xnode["fiz_def"].InnerText.Trim());
                        mag_at = Convert.ToInt32(xnode["mag_at"].InnerText.Trim());
                        mag_def = Convert.ToInt32(xnode["mag_def"].InnerText.Trim());
                        accuracy = Convert.ToInt32(xnode["accuracy"].InnerText.Trim());
                        evasion = Convert.ToInt32(xnode["evasion"].InnerText.Trim());
                        speed = Convert.ToInt32(xnode["speed"].InnerText.Trim());
                        isMelee = Convert.ToBoolean(xnode["isMelee"].InnerText.Trim());
                        description = xnode["description"].InnerText.Trim();
                    }*/
        }
    }
}

