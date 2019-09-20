using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System;

public class Test : MonoBehaviour
{
    public GameObject player;
    Vector3 target;
    public float speed = 0.5f;
    public bool isMove = true;
    public bool isClick = false;
    void Start()
    {
        target = player.GetComponent<Transform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            target = Input.mousePosition; 

        if (target != player.GetComponent<Transform>().localPosition)
        {
             Vector3 move = (target - player.GetComponent<Transform>().localPosition);
            player.GetComponent<Transform>().localPosition += move * Time.deltaTime;
            
        } 
    }
    public void click()
    {
        isClick = true;
    }

}
