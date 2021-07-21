using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System;
using UnityEngine;


namespace Assets.Scrits
{
    class Character
    {
        XmlDocument xmlDoc = new XmlDocument();

        public string rase;
        public string clas;
        public int fiz_at=0,
            fiz_def=0,
            mag_at=0,
            mag_def=0,
            accuracy=0,
            evasion=0,
            speed=0;        
        public bool isMelee;
        public List<item> item_p;
        public Character()
        {
            Load();
        }
        public Character(string rase, string clas)
        {
            this.clas = clas;
            this.rase = rase;
            switch (clas)
            {
                case "Berserk":
                    fiz_at += 120;
                    fiz_def += 60;
                    mag_at += 0;
                    mag_def += 30;
                    accuracy += 80;
                    evasion += 30;
                    speed = 0;
                    isMelee = true;
                    break;

                case "Sorcerer":
                    fiz_at += 40;
                    fiz_def += 30;
                    mag_at += 120;
                    mag_def += 60;
                    accuracy += 100;
                    evasion += 30;
                    speed = 0;
                    break;

                case "Gunslinger":
                    fiz_at += 100;
                    fiz_def += 40;
                    mag_at += 60;
                    mag_def += 40;
                    accuracy += 140;
                    evasion += 60;
                    speed = 0;
                    break;

                case "Spiritmaster":
                    fiz_at += 60;
                    fiz_def += 70;
                    mag_at += 40;
                    mag_def += 60;
                    accuracy += 60;
                    evasion += 20;
                    speed = 0;
                    break;
            }
            switch (rase)
            {
                case "Orc":
                    fiz_at += 40;
                    fiz_def += 20;
                    mag_at += 0;
                    mag_def += 0;
                    accuracy += -20;
                    evasion += -20;
                    speed = 0;
                    isMelee = true;
                    break;

                case "Elf":
                    fiz_at += -20;
                    fiz_def += -20;
                    mag_at += +30;
                    mag_def += +30;
                    accuracy += 0;
                    evasion += 0;
                    speed = 0;
                    break;

                case "Robot":
                    fiz_at += +10;
                    fiz_def += +10;
                    mag_at += -30;
                    mag_def += +10;
                    accuracy += +40;
                    evasion += +20;
                    speed = 0;
                    break;

                case "Spiritmaster":
                    fiz_at += -20;
                    fiz_def += +20;
                    mag_at += -20;
                    mag_def += +20;
                    accuracy += 0;
                    evasion += 0;
                    speed = 0;
                    break;
            }
        }

        public void Load()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.dataPath + "/Characters/Character.xml");
            XmlElement xmlEle = xmlDoc.DocumentElement;
            foreach (XmlNode xnode in xmlEle["Character"].ChildNodes)//attr, items, skills
                foreach (XmlNode child in xnode.ChildNodes)
                    if (xnode.Name == "Attributes")
                    {
                        for (int i = 0; i < child.Attributes.Count; i++)
                            switch (child.Attributes[i].Name)
                            {
                                case "rase":
                                    rase = child.Attributes[i].Value;
                                    break;
                                case "clas":
                                    clas = child.Attributes[i].Value;
                                    break;
                                case "fiz_at":
                                    fiz_at = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "fiz_def":
                                    fiz_def = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "mag_at":
                                    mag_at = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "mag_def":
                                    mag_def = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "accuracy":
                                    accuracy = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "speed":
                                    speed = Convert.ToInt32(child.Attributes[i].Value);
                                    break;
                                case "isMelee":
                                    isMelee = Convert.ToBoolean(child.Attributes[i].Value);
                                    break;
                            }
                    }

        }
        public void add_characteristic(string characteristic, int add)
        {
            switch(characteristic)
            {
                case "fiz_at":
                    fiz_at += add;
                    if (fiz_at > 200)
                        fiz_at = 200;
                    break;
                case "fiz_def":
                    fiz_def += add;
                    if (fiz_def > 100)
                        fiz_def = 100;
                    break;
                case "mag_at":
                    mag_at += add;
                    if (mag_at > 200)
                        mag_at = 200;
                    break;
                case "mag_def":
                    mag_def += add;
                    if (mag_def > 100)
                        mag_def = 100;
                    break;
                case "accuracy":
                    accuracy += add;
                    if (accuracy > 200)
                        accuracy = 200;
                    break;
                case "evasion":
                    evasion += add;
                    if (accuracy > 100)
                        accuracy = 100;
                    break;
                case "speed":
                    speed += add;
                    break;
            }
        }
        public void add_item(item item)
        {
            item_p.Add(item);
            {
                add_characteristic("fiz_at", item.fiz_at);
                add_characteristic("fiz_def", item.fiz_def);
                add_characteristic("mag_at", item.mag_at);
                add_characteristic("mag_def", item.mag_def);
                add_characteristic("accuracy", item.accuracy);
                add_characteristic("evasion", item.evasion);
                add_characteristic("speed", item.speed);
            }
        }
        public void del_item(item item)
        {
            item_p.Remove(item);
            {
                add_characteristic("fiz_at", -item.fiz_at);
                add_characteristic("fiz_def", -item.fiz_def);
                add_characteristic("mag_at", -item.mag_at);
                add_characteristic("mag_def", -item.mag_def);
                add_characteristic("accuracy", -item.accuracy);
                add_characteristic("evasion", -item.evasion);
                add_characteristic("speed", -item.speed);
            }
        }
    }
}
