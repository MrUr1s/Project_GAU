using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Assets.Scrits
{
    class Global
    {
        public static Character character;
        public static List<item> items;
        public void Load_item()
        {
            int id = 0;
            string name;
            string type;
            bool isMelee;
            int fiz_at = 0,
               fiz_def = 0,
               mag_at = 0,
               mag_def = 0,
               accuracy = 0,
               evasion = 0,
               speed = 0;
            string description;

            string path = "Assets/Items/Items.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlElement xmlEle = xmlDoc.DocumentElement;
            foreach (XmlNode xnode in xmlEle.ChildNodes[0].ChildNodes)//attr, items, skills
            {
                int i = 0;
                id = Convert.ToInt32(xnode.Attributes[0].Value.Trim());
                name = xnode.ChildNodes.Item(i++).InnerText.Trim();
                type = xnode.ChildNodes.Item(i++).InnerText.Trim();
                fiz_at = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                fiz_def = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                mag_at = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                mag_def = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                accuracy = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                evasion = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                speed = Convert.ToInt32(xnode.ChildNodes.Item(i++).InnerText.Trim());
                isMelee = Convert.ToBoolean(xnode.ChildNodes.Item(i++).InnerText.Trim());
                description = xnode.ChildNodes.Item(i++).InnerText.Trim();
                items.Add(new item(id, name, type, isMelee, fiz_at, fiz_def, mag_at, mag_def, accuracy, evasion, speed, description));
            }
        }
        public void Save_item()
        {

        }

    }
}
