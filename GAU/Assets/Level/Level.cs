using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{
    public class Level : MonoBehaviour
    {
        // public RectTransform target;

        private bool flag = false;
        private bool selected = false;
        public GameObject GO = null;
        [ContextMenu("Start")]
        void Start()
        {
        }
        private void OnMouseDown()
        {
            if (flag)
            {
                selected = false;
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1, 1, 1);
            }
            else
            {
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0);
                selected = true;
            }
            Debug.Log(this.name.Split(' ')[0]+"|"+this.name.Split(' ')[1]);
            flag = !flag;
        }
        void OnTriggerEnter(Collider other)
        {
            GO = other.gameObject;
        }
        void OnTriggerExit(Collider other)
        {

            GO = null;
        }

    }
}
