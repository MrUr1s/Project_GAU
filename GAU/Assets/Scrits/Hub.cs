using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Assets.Scrits
{
    public static class Map
    {
        public static Level[,] map;
        public static void Create(int x, int y)
        {
            map = new Level[x, y];
        }

    }


    public class Hub : MonoBehaviour
    {
        [System.Serializable]
        public struct Target
        {
            public int? x;
            public int? y;            
        }
        [SerializeField]
        public static Target target;

        public GameObject character_window, invetory;
        public Text col_step_text;
        public Transform player;
        public Transform evasion, defense;
        public float speed = 5f;
        public bool isGame = true;
        public bool isMove = false;
        public int col_step;
        public int step;
        Assets.Scrits.Global global = new Assets.Scrits.Global();
        void Awake()
        {
            global.Change();
        }

        void Start()
        {
            //target.position = player.position;
            step = col_step;
            col_step_text.text = step.ToString();
        }

        void Update()
        {
            if (isGame)
            {
                if (target.x != null && target.y != null)
                {
                    int x = target.x.GetValueOrDefault(), y = target.y.GetValueOrDefault();
                    if (Input.GetKey(KeyCode.Space))
                        isMove = !isMove;
                    if (isMove)
                    {
                        Move(player.GetComponent<Player_sc>().Move(x, y), ref player.GetComponent<Player_sc>()._pos.x,
                           ref player.GetComponent<Player_sc>()._pos.y, x, y);


                    }
                }
                //if (step != 0 && !isMove && player.position != target.position)
                //{
                //    player.position = Vector3.MoveTowards(player.position, target.position, speed);
                //    step--;
                //}
                //else isMove = true;
                //col_step_text.text = step.ToString();
            }
        }
        void Move(int[,] map, ref int curentposx, ref int curentposy, int targetposx, int targetposy)
        {
            if (curentposx != targetposx || curentposy != targetposy)
            {                
                if (map[curentposx + 1, curentposy] == map[curentposx, curentposy] - 1)
                {
                    curentposx += 1;
                    player.position = Vector3.MoveTowards(player.position, Map.map[curentposx, curentposy].GetComponent<Transform>().position, speed);
                    return;
                }
                if (map[curentposx - 1, curentposy] == map[curentposx, curentposy] - 1)
                {
                    curentposx -= 1;
                    player.position = Vector3.MoveTowards(player.position, Map.map[curentposx, curentposy].GetComponent<Transform>().position, speed);
                    return;
                }
                if (map[curentposx, curentposy + 1] == map[curentposx, curentposy] - 1)
                {
                    curentposy += 1;
                    player.position = Vector3.MoveTowards(player.position, Map.map[curentposx, curentposy].GetComponent<Transform>().position, speed);
                    return;
                }
                if (map[curentposx, curentposy - 1] == map[curentposx, curentposy] - 1)
                {
                    curentposy -= 1;
                    player.position = Vector3.MoveTowards(player.position, Map.map[curentposx, curentposy].GetComponent<Transform>().position, speed);
                    return;
                }
            }
            else isMove = false;
        }

        
        void Fight(GameObject enemy_go)
        {
            Enemy enemy = enemy_go.GetComponent<Enemy>();
            Assets.Scrits.Player_sc player = GameObject.FindGameObjectWithTag("Player").GetComponent<Assets.Scrits.Player_sc>();
            if (player.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                if (player.fiz_at - enemy.fiz_def > 0)
                {
                    enemy.hp -= player.fiz_at - enemy.fiz_def;
                    StartCoroutine(hit(enemy_go, "Hit", enemy.fiz_def - player.fiz_at));
                }
                else
                    StartCoroutine(hit(enemy_go, "Defense"));
            else
                StartCoroutine(hit(enemy_go, "Evasion"));
            if (enemy.hp <= 0)
                kill(enemy_go);
        }

        IEnumerator hit(GameObject enemy, string what, int hit = 0)
        {

            Canvas ui = enemy.GetComponentInChildren<Canvas>();
            Debug.Log(ui.GetComponent<RectTransform>().name);
            if (what == "Evasion")
                Instantiate(evasion, ui.GetComponent<RectTransform>()).name = "Evasion";
            else if (what == "Defense")
                Instantiate(defense, ui.GetComponent<RectTransform>()).name = "Defense";
            else if (what == "Hit")
            {
                Instantiate(defense, ui.GetComponent<RectTransform>());
                ui.GetComponentInChildren<Text>().text = hit.ToString();
            }
            for (float y = 0; y <= 1; y += 0.025f)
            {
                ui.GetComponent<RectTransform>().localPosition = new Vector3(0, y, 0);
                ui.GetComponentInChildren<Text>().color = new Color(0, 0, 0, y);
                yield return null;
            }
            Destroy(ui.GetComponentInChildren<Text>().gameObject);
        }

        void kill(GameObject enemy_go)
        {
            Destroy(enemy_go);
        }
        void add_item(GameObject item)
        {
            GetComponent<Hub>().invetory.GetComponentInChildren<Invetory_panel_create>().add_item(item);
            Destroy(item);
        }

        public void Characteristic_click()
        {
            character_window.SetActive(!character_window.activeSelf);
            isGame = !isGame;
        }

        public void Run_click()
        {
            if (isGame)
            {
                if (step == 0)
                    step = col_step;
                isMove = false;

            }
        }

    }
}