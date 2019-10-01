using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_panel_create : MonoBehaviour
{
    //public GameObject item_panel;
  //  public List<GameObject> items_panel;
    // Start is called before the first frame update
    void Start()
    {
        int count = 10;
        for (int i = 0; i < count; i++)
            print(i % 4);
        //item_panel = Instantiate(items_panel[0], new Vector3(50, 50, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
