using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{    
    public class Level : MonoBehaviour
    {
        public GameObject enemy;
        public int count;
        public float delt;
        void Start()
        {
            count =(int) (GetComponent<RectTransform>().sizeDelta.x * GetComponent<RectTransform>().sizeDelta.y/(20000*4) );
            if (enemy != null)            
                for (int i = 0; i < count; i += 1)
                    {
                    Quaternion temp = new Quaternion(0, 0, 0, 1);
                    switch (GetComponent<RectTransform>().localRotation.z)
                    {                        
                        case 90:
                            temp = new Quaternion(0, 0, -0.7f, 0.7f);
                            break;
                        case -90:
                            temp = new Quaternion(0, 0, 0.7f, 0.7f);
                            break;
                        case 180:
                        case -180:
                            temp = new Quaternion(0, 0, 1, 0);
                            break;
                    }
                  
                        
                    Instantiate(enemy,(Vector2) GetComponent<RectTransform>().localPosition +
                        new Vector2(Random.Range(-(GetComponent<RectTransform>().sizeDelta.x / 2 - delt),  GetComponent<RectTransform>().sizeDelta.x/2 - delt), Random.Range(-(GetComponent<RectTransform>().sizeDelta.y / 2-delt), GetComponent<RectTransform>().sizeDelta.y/2 - delt)),
                        temp, GetComponent<RectTransform>());
                    }
        }
    }
}
