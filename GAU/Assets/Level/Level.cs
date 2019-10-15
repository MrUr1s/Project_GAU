using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{
    public class Level : MonoBehaviour
    {
        public GameObject lev_pos;
        public List<GameObject> _lev_pos;
        void Start()
        {
            for (int x = 0; x < GetComponent<RectTransform>().sizeDelta.x; x += 100)
                for (int y = 0; y < GetComponent<RectTransform>().sizeDelta.y; y += 100)
                    _lev_pos.Add(Instantiate(lev_pos, GetComponent<RectTransform>().localPosition + new Vector3(x, y) - (Vector3)GetComponent<RectTransform>().sizeDelta / 2, Quaternion.identity, GetComponent<RectTransform>()));
            if (name != "0") Active(false);
        }
        void Active(bool _bool)
        {
            foreach (GameObject temp in _lev_pos)
            {
                temp.gameObject.SetActive(_bool);
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            Active(true);
        }
        void OnTriggerExit2D(Collider2D other)
        {
            Active(false);
        }
    }
}
