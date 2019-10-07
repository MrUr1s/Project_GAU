using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System;
public class Invetory_panel_create : MonoBehaviour
{
    public List<GameObject> items_panel;
    public GameObject info_item;
    public List<GameObject> items;
    public GameObject item;
    void Awake()
    {      
        foreach (RectTransform item_panel in GetComponentInChildren<RectTransform>())
        {
            items_panel.Add(item_panel.gameObject);
        }
    }
    void Start()
    {
        GameObject temp = item;
        XDocument xDoc = XDocument.Load(Assets.Scrits.Global.path);
        foreach (XElement xe in xDoc.Element("Items").Elements("item"))
            if (xe.Attribute("id") != null)
            {
                temp.GetComponent<Assets.Scrits.Items>().id = Convert.ToInt32(xe.Attribute("id").Value);
                add_item(temp);
            }        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                          y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            RaycastHit2D Level = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Level"));
            RaycastHit2D Item_ray = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Items"));
            // Debug.Log(Level.collider);
            Debug.Log(Item_ray.collider);
            if (Item_ray.collider != null)
                info(Item_ray.collider.gameObject);
        }
    }
    public void add_item(GameObject item_add)
    {
        foreach (GameObject item in items_panel)
            if (item.GetComponentInChildren<Rigidbody2D>() == null)
            {
                Instantiate(item_add, item.GetComponent<RectTransform>().position, Quaternion.identity, item.GetComponent<RectTransform>());                
                break;                
            }       
    }
    public void info(GameObject item_ray)
    {
        items[0].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().item_name;
        items[1].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().type;
        items[2].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().fiz_at.ToString();
        items[3].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().fiz_def.ToString();
        items[4].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().mag_at.ToString();
        items[5].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().mag_def.ToString();
        items[6].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().accuracy.ToString();
        items[7].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().evasion.ToString();
        items[8].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().speed.ToString();
        items[9].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().isMelee.ToString();
        items[10].GetComponent<Text>().text = item_ray.GetComponent<Assets.Scrits.Items>().description;
        info_item.SetActive(true);
    }

    public void del_item(GameObject item_add)
    {
        Destroy(item_add);
    }
    void save()
    {
        XDocument xDoc = XDocument.Load(Assets.Scrits.Global.path);
        XElement root = xDoc.Element("Items");
        root.Elements("Item").Remove();
        foreach (GameObject item in items_panel)
            if (item.GetComponentInChildren<Rigidbody2D>() != null)
            {
                Assets.Scrits.Items temp = item.GetComponentInChildren<Assets.Scrits.Items>();
                root.Add(new XElement("item", new XAttribute("id", temp.id),
                    new XElement("name", temp.item_name),
                    new XElement("type", temp.type),
                    new XElement("fiz_at", temp.fiz_at),
                    new XElement("fiz_def", temp.fiz_def),
                    new XElement("mag_at", temp.mag_at),
                    new XElement("mag_def", temp.mag_def),
                    new XElement("accuracy", temp.accuracy),
                    new XElement("evasion", temp.evasion),
                    new XElement("speed", temp.speed),
                    new XElement("isMelee", temp.isMelee),
                    new XElement("description", temp.description)
                    ));
            }
        xDoc.Save(Assets.Scrits.Global.path);
    }    
}
