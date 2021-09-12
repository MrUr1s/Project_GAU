using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{
    public class Level : MonoBehaviour
    {
        private bool flag = false;
        public bool selected = false;
        public GameObject GO = null;
        public int x;
        public int y;

        private void Update()
        {
            if (selected)
            {
                flag = true;
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0);
            }
            else
            {
                flag = false;
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1, 1, 1);
            }
        }
        private void OnMouseDown()
        {
            if (this.GO == null)
            {
                selected = !selected;
                if (selected)
                {
                    Hub.target.x = x;
                    Hub.target.y = y;
                }
                else
                {
                    Hub.target.x = Hub.target.y = null;
                }
                Unselected();
            }
        }
        void OnTriggerEnter(Collider other)
        {
            GO = other.gameObject;
            if (GO.name == "player")
            {

            }
        }
        void OnTriggerExit(Collider other)
        {
            GO = null;
        }
        void Unselected()
        {
            for (int x=0;x<Map.map.GetUpperBound(0)+1;x++)
                for (int y=0;y< Map.map.GetUpperBound(1)+1;y++)
                {
                    if (this !=Map.map[x, y].GetComponent<Level>())
                    Map.map[x, y].GetComponent<Level>().selected = false;
                }
        }

    }
}
