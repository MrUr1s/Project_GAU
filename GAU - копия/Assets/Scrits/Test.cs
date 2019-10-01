using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Xml.Linq;
using System;

public class Test : MonoBehaviour
{
    public Transform player,target;
    public float speed = 0.5f;
    public bool isMove = true;
    public bool isClick = false;
    public Vector3 move;
    void Start()
    {
        target.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {            
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),new Vector3(0,0,1), out hit);
            if (hit.collider != null) 
            if(hit.collider.GetComponentInParent<RectTransform>().tag=="Game window")
                target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }

        if (target.position != player.position)
        {
            move = (target.position - player.position)*Time.deltaTime;
            if (Mathf.Abs(move.x) <= 0.01f)
                move.x = 0;
            if (Mathf.Abs(move.y) <= 0.01f)
                move.y = 0;
            player.position += move;
            
        } 
    }
    public void click()
    {
        
    }

}
