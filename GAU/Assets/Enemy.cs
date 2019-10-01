using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public int id;
    public int fiz_at = 0,
           fiz_def = 0,
           mag_at = 0,
           mag_def = 0,
           accuracy = 0,
           evasion = 0,
           speed = 0;
    public bool isMelee = false;
    void Start()
    {
        if (id == -1)
            id = Random.Range(1000000, 2000000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
