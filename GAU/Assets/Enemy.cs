using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public int id=-1;
    public int fiz_at = 0,
           fiz_def = 0,
           mag_at = 0,
           mag_def = 0,
           accuracy = 0,
           evasion = 0,
           speed = 0;
    public bool isMelee = false;
    public GameObject item;
    public int count = 0;

    void Start()
    {
        if (id == -1)
            id = Random.Range(1000000, 2000000);
    }

    void OnDestroy()
    {
        for (int i = 0; i < count; i++)
        {
            item.GetComponent<Assets.Scrits.Items>();
            Instantiate(item, GetComponentInParent<RectTransform>());
        }
    }

}
