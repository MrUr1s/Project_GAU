using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using UnityEngine;

namespace Assets.Scrits
{
    class Global : MonoBehaviour
    {
        public TextAsset items_xml;
        public bool isFirst = true;
        public static Character character;

        public static string file = "/Items.xml";
        public static string path;
        public static bool Android = false;
        
        public void Change()
        {
            if (Android)
                path = Application.persistentDataPath + file;
            else
                path = Application.dataPath + file;
        }
        void Awake()
        {
            if (PlayerPrefs.GetString("isFirst") == "")
                isFirst = true;
            else
                isFirst = Convert.ToBoolean(PlayerPrefs.GetString("isFirst"));
            Change();

            if (isFirst)
                try
                {
                    XDocument xDoc = new XDocument(new XElement("Items", ""));
                    xDoc.Save(path);
                    Debug.Log("1");
                }
                catch (Exception)
                {
                    XDocument xDoc = new XDocument(new XElement("Items", ""));
                    xDoc.Save(path);
                    Debug.Log("2");
                }

        }
        void Start()
        {
            if (isFirst)
            {
                XDocument xDoc = XDocument.Load(path);
                XElement root = xDoc.Element("Items");
                XmlDocument xmld = new XmlDocument();
                xmld.LoadXml(items_xml.text);
                XmlElement xmle = xmld.DocumentElement;
                foreach (XmlNode xnode in xmle)
                    if (xnode.Attributes.Count > 0)
                    {
                        root.Add(new XElement("item", new XAttribute("id", xnode.Attributes.GetNamedItem("id").Value.Trim()),
                            new XElement("name", xnode["name"].InnerText.Trim()),
                            new XElement("type", xnode["type"].InnerText.Trim()),
                            new XElement("fiz_at", xnode["fiz_at"].InnerText.Trim()),
                            new XElement("fiz_def", xnode["fiz_def"].InnerText.Trim()),
                            new XElement("mag_at", xnode["mag_at"].InnerText.Trim()),
                            new XElement("mag_def", xnode["mag_def"].InnerText.Trim()),
                            new XElement("accuracy", xnode["accuracy"].InnerText.Trim()),
                            new XElement("evasion", xnode["evasion"].InnerText.Trim()),
                            new XElement("speed", xnode["speed"].InnerText.Trim()),
                            new XElement("isMelee", xnode["isMelee"].InnerText.Trim()),
                            new XElement("description", xnode["description"].InnerText.Trim())));
                    }
                xDoc.Save(path);
                isFirst = false;
                PlayerPrefs.SetString("isFirst", isFirst.ToString());
            }
        }      
        public void Save_item()
        {

        }

    }
}