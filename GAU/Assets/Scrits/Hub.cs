using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml.Linq;

namespace Assets.Scrits {
    public class Hub : MonoBehaviour {

        public GameObject stat_panel, invetory, window;
        public GameObject[] stats;
        Character character;
        public Transform player, target;
        public Transform evasion, defense;
        public float speed = 5f;
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
                float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                RaycastHit2D Enemy = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Enemy"));
                RaycastHit2D Game_window = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Game window"));
                RaycastHit2D Level = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Level"));
                RaycastHit2D Item_ray = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Items"));
                if (Enemy.collider == null && Game_window.collider != null && Level.collider != null && Item_ray.collider == null)
                    if ((Game_window.collider.tag == "Game window") && (Level.collider.tag == "Level"))
                        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                if (Item_ray.collider != null)
                    if (Item_ray.collider.tag == "Items")
                        add_item(Item_ray.collider.gameObject);

                if (Enemy.collider != null)
                    if (Enemy.collider.tag == "Enemy")
                        Fight(Enemy.collider.gameObject);
            }
            player.position = Vector3.MoveTowards(player.position, target.position, speed);


        }
        void Fight(GameObject enemy_go)
        {
            Enemy enemy = enemy_go.GetComponent<Enemy>();
            Assets.Scrits.Player_sc player = GameObject.FindGameObjectWithTag("Player").GetComponent<Assets.Scrits.Player_sc>();
            if (player.accuracy - enemy.evasion > 0 || Random.Range(1, 100) == 1)
                if (player.fiz_at - enemy.fiz_def > 0)
                    enemy.hp -= player.fiz_at - enemy.fiz_def;
                else
                {
                    StartCoroutine(hit(enemy_go.GetComponentInChildren<Canvas>(), "Defense"));
                }
            else
            {
                StartCoroutine(hit(enemy_go.GetComponentInChildren<Canvas>(), "Evasion"));
            }


            if (enemy.hp <= 0)
                Destroy(enemy_go);
            Debug.Log(enemy.hp);
        }
        IEnumerator hit(Canvas ui, string what)
        {
            if (what == "Evasion")
                Instantiate(evasion, ui.GetComponent<RectTransform>()).name = "Evasion";
            else if (what == "Defense")
                Instantiate(defense, ui.GetComponent<RectTransform>()).name = "Defense"; ;
            for (float y = 0; y <= 1; y += 0.025f)
            {
                ui.GetComponent<RectTransform>().localPosition = new Vector3(0, y, 0);
                ui.GetComponentInChildren<Text>().color = new Color(0, 0, 0, y);
                yield return null;
            }
            Destroy(ui.GetComponentInChildren<Text>().gameObject);
        }
        void add_item(GameObject item)
        {
           GetComponent<Hub>().invetory.GetComponentInChildren<Invetory_panel_create>().add_item(item);
          //  Destroy(item);
        }
        public void stat()
        {
            character = new Character();
            stat_panel.SetActive(!stat_panel.activeSelf);
            stats[0].GetComponent<Text>().text = character.rase;
            stats[1].GetComponent<Text>().text = character.clas;
            stats[2].GetComponent<Text>().text = character.fiz_at.ToString();
            stats[3].GetComponent<Text>().text = character.fiz_def.ToString();
            stats[4].GetComponent<Text>().text = character.mag_at.ToString();
            stats[5].GetComponent<Text>().text = character.mag_def.ToString();
            stats[6].GetComponent<Text>().text = character.accuracy.ToString();
            stats[7].GetComponent<Text>().text = character.evasion.ToString();
            stats[8].GetComponent<Text>().text = character.speed.ToString();
            stats[9].GetComponent<Text>().text = character.isMelee.ToString();
        }
        public void Invetory()
        {
            invetory.SetActive(!invetory.activeSelf);
        }
       
    }

}