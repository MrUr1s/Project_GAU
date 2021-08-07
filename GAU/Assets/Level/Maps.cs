using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrits
{
    public class Maps : MonoBehaviour
    {
        public GameObject levels, H_Wall;

        [System.Serializable]
        public struct Size
        {
            public int x;
            public int y;
        }
        public float placehold=.1f;
        private int x;
        private int y;
        public Size size;
        Vector2 level_size;
        bool isclick = false;
        bool b = true;
        Vector3 pos;
        [ContextMenu("Start")]
        void Start()
        {
            pos = this.transform.position; 
            level_size = levels.GetComponent<Renderer>().bounds.size;
            x = y = 0;
            Square();
        }

        void Square()
        {            
            Map.Create(size.x, size.y);
            for (; x < size.x; x++)
                for (y = 0; y < size.y; y++)
                {
                    var lev = Instantiate(levels, new Vector3(x * level_size.x, y * level_size.y, 1)+pos,
                        Quaternion.identity, this.gameObject.transform);
                    lev.name = x + " " + y;
                    Map.map[x,y] = lev.GetComponent<Level>();
                    Map.map[x, y].x = x;
                    Map.map[x, y].y = y;
                }
            Wall(ref Map.map);
        }

        void Wall(ref Level[,] map)
        {
            for (int y = 0; y <= size.y-1; y++)
                for (int x = 0; x <= size.x-1; x++)
                {
                    if (y == 0 || x == 0 || x == size.x-1 || y == size.y-1)
                        map[x, y].GO = H_Wall;
                    else
                    {
                        if ((x % 2 == 0) && (y % 2 == 0))
                            if (Random.value > placehold)
                            {
                                map[x, y].GO = H_Wall;
                                int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                                int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                                map[x + a, y + b].GO = H_Wall;
                            }
                    }
                   
                }
            for (int y=0;y<size.y;y++)
                for (int x=0;x<size.x; x++)
                    if (map[x, y].GO == H_Wall)
                    {
                        Instantiate(H_Wall, new Vector3(x * level_size.x, y * level_size.y, 1) + pos,
                                    Quaternion.identity, this.gameObject.transform);

                       // Debug.Log(x + " " + y);
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