using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml.Linq;


public class Hub : MonoBehaviour
{

    public GameObject character_window, invetory;
    public Text col_step_text;
    public Transform player, target;
    public Transform evasion, defense;
    public float speed = 5f;
    public bool isGame = true;
    public bool isMove = true;
    public int col_step;
    public int step;
    Assets.Scrits.Global global = new Assets.Scrits.Global();
    void Awake()
    {
        global.Change();
    }

    void Start()
    {   
        target.position = player.position;
        step = col_step;
        col_step_text.text = step.ToString();
    }

    void Update()
    {
        if (isGame)
        {
            if (Input.GetMouseButtonDown(0) && isMove)
            {
                float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                RaycastHit2D all_ray = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0));
                Debug.Log(all_ray.collider);

                RaycastHit2D Enemy = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Enemy"));
                RaycastHit2D Game_window = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Game window"));
                RaycastHit2D Level = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Level"));
                RaycastHit2D Item_ray = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Items"));
                if (Enemy.collider == null && Game_window.collider != null && Level.collider != null && Item_ray.collider == null)
                    if ((Game_window.collider.tag == "Game window") && (Level.collider.tag == "Level"))
                    {
                        target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                        Debug.Log(Level.collider.name);
                    }

                if (Item_ray.collider != null)
                    if (Item_ray.collider.tag == "Items")
                        add_item(Item_ray.collider.gameObject);

                if (Enemy.collider != null)
                    if (Enemy.collider.tag == "Enemy")
                        Fight(Enemy.collider.gameObject);
            }
            if (step != 0 && !isMove && player.position != target.position)
            {
                player.position = Vector3.MoveTowards(player.position, target.position, speed);
                step--;               
            }
            else isMove = true;
            col_step_text.text = step.ToString();
        }
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
