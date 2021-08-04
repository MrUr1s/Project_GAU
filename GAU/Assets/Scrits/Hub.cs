using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Assets.Scrits
{
    public static class Map
    {
        public static int[,] map;
        public static void Create(int x, int y)
        {
            map = new int[x, y];
        }

    }
}

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
        //target.position = player.position;
        step = col_step;
        col_step_text.text = step.ToString();
    }

    void Update()
    {
        if (isGame)
        {
            if (Input.GetMouseButtonDown(0) && isMove)
            {
            
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
    int[,] map(Vector3 player, Vector3 target)
    {
        
        return null;
    }
    Vector3 Move(Vector3 player,Vector3 target,int speed)
    {
        RaycastHit2D player_map = Physics2D.Raycast((Vector2)player, new Vector2(0, 0), 1000, 1 << LayerMask.NameToLayer("Level"));
        Assets.Scrits.Maps maps = new Assets.Scrits.Maps();
        
        return new Vector3();
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
