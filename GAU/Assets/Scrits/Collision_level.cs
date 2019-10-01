using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scrits
{
    
    public class Collision_level : MonoBehaviour
    {
        public GameObject level_pos;

        void Start()
        {
            if (level_pos != null)
            {
                Vector2 pos = new Vector2(GetComponent<RectTransform>().localPosition.x - GetComponent<RectTransform>().sizeDelta.x / 2f + 25
                    , GetComponent<RectTransform>().localPosition.y - GetComponent<RectTransform>().sizeDelta.y / 2f + 25);
                for (int x = 0; x < GetComponent<RectTransform>().sizeDelta.x; x += 50)
                    for (int y = 0; y < GetComponent<RectTransform>().sizeDelta.y; y += 50)
                    {
                        Instantiate(level_pos, pos + new Vector2(x, y), Quaternion.identity, GetComponent<RectTransform>());
                    }
            }

        }
    }
}
