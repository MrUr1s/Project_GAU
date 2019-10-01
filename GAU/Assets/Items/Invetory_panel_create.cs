using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_panel_create : MonoBehaviour
{
    public List<GameObject> items_panel;
    void Awake()
    {
        foreach (RectTransform item_panel in GetComponentInChildren<RectTransform>())
        {
            items_panel.Add(item_panel.gameObject);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit2D Level = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Level"));
        RaycastHit2D Item_ray = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Items"));
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
    public void del_item(GameObject item_add)
    {
        Destroy(item_add);
    }
}
