using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{
    public class Maps : MonoBehaviour
    {
        public GameObject levels, H_Wall,V_Wall;
        
        [System.Serializable]
        public struct Size
        {
            public int x;
            public int y;
        }
        private int x;
        private int y;
        public Size size;
        Vector2 level_size;
        bool isclick = false;

        [ContextMenu("Start")]
        void Start()
        {            
            level_size = levels.GetComponent<Renderer>().bounds.size;
            x = y = 0;
            Square();         
        }

        void Square()
        {
            Map.Create(size.x, size.y);
            for (; x < size.x; x++)                 
                for (y = 0 ; y < size.y; y++)
                {
                    var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1),
                        Quaternion.identity, this.gameObject.transform);
                    Algoritm(x, y, (byte)Random.Range(1,4));
                    lev.name = x + " " + y;
                }            
        }
        void Algoritm(int x,int y,byte rnd)
        {
            switch (rnd)
            {
                case 1:
                    Instantiate(H_Wall, new Vector3(x * level_size.x, y * level_size.y - level_size.y / 2, 1),
                                Quaternion.identity, this.gameObject.transform);
                    break;
                case 2:
                    Instantiate(V_Wall, new Vector3(x * level_size.x - level_size.x / 2, y * level_size.y, 1),
                                Quaternion.identity, this.gameObject.transform);                    
                    break;
                case 3:
                    Instantiate(H_Wall, new Vector3(x * level_size.x, y * level_size.y + level_size.y / 2, 1),
                                Quaternion.identity, this.gameObject.transform);
                    break;
                case 4:
                    Instantiate(V_Wall, new Vector3(x * level_size.x - level_size.x / 2, y * level_size.y, 1),
                             Quaternion.identity, this.gameObject.transform);
                    break;
            }           
            Map.map[x, y] = rnd;
        }
        void f(int l)
        {
            int temp_x;
                int temp_y;
            switch (l)
            {
                case 1:
                    y -= Random.Range(1, 3);
                    temp_x = x;
                    temp_y = y;
                    for (; x < temp_x + 3; x++)
                    {
                        var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1),
                            Quaternion.identity, this.gameObject.transform);
                        lev.name = x + " " + y;
                    }
                    for (; y < temp_y + 3; y++)
                    {
                        var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1),
                            Quaternion.identity, this.gameObject.transform);
                        lev.name = x + " " + y;
                    }
                    break;
                case 2:
                    y -= Random.Range(1, 3);
                    temp_x = x;
                    temp_y = y;
                    for (; x < temp_x + 3; x++)
                    {
                        var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1),
                            Quaternion.identity, this.gameObject.transform);
                        lev.name = x + " " + y;
                    }
                    for (; y < temp_y + 3; y++)
                    {
                        var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1),
                            Quaternion.identity, this.gameObject.transform);
                        lev.name = x + " " + y;
                    }
                    break;
            }
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape) && !isclick)
            {
                isclick = true;
                Delete();
            }

            if (Input.GetKey(KeyCode.R) && isclick)
            {
                isclick = false;
                Start();
            }

        }
        public void Delete()
        {
            foreach (var go in GameObject.FindGameObjectsWithTag("Level"))
                if (go.layer == LayerMask.NameToLayer("Level"))
                {
                    Destroy(go);
                }
        }
    }
}