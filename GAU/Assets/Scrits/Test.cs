using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
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
            if (Enemy.collider == null && Game_window.collider != null && Level.collider != null)
                if ((Game_window.collider.tag == "Game window") && (Level.collider.tag == "Level"))
                {
                    target.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

                }
            if (Enemy.collider != null)
                if (Enemy.collider.tag == "Enemy")
                {
                    Fight(Enemy.collider.gameObject);
                }
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
            StartCoroutine(hit(enemy_go.GetComponentInChildren<Canvas>(),"Evasion"));
        }


        if (enemy.hp <= 0)
            Destroy(enemy_go);
        Debug.Log(enemy.hp);
    }
    IEnumerator hit(Canvas ui,string what)
    {
        if (what == "Evasion")
            Instantiate(evasion,ui.GetComponent<RectTransform>()).name= "Evasion";
        else if (what == "Defense")
            Instantiate(defense, ui.GetComponent<RectTransform>()).name = "Defense"; ;
        for (float y = 0; y <= 1; y += 0.025f)
        {
            ui.GetComponent<RectTransform>().localPosition = new Vector3(0, y, 0);
            ui.GetComponentInChildren<Text>().color = new Color(0,0, 0, y);
            yield return null;
        }
        Destroy(ui.GetComponentInChildren<Text>().gameObject);
    }

}

/*    float x1 = hit[0].collider.GetComponentInParent<RectTransform>().position.x - hit[0].collider.GetComponentInParent<RectTransform>().sizeDelta.x / 2,
        x2 = hit[0].collider.GetComponentInParent<RectTransform>().position.x + hit[0].collider.GetComponentInParent<RectTransform>().sizeDelta.x / 2,
        y1 = hit[0].collider.GetComponentInParent<RectTransform>().position.y - hit[0].collider.GetComponentInParent<RectTransform>().sizeDelta.y / 2,
        y2 = hit[0].collider.GetComponentInParent<RectTransform>().position.y + hit[0].collider.GetComponentInParent<RectTransform>().sizeDelta.y / 2;
    if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 25 <= x2) && (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 25 >= x1) &&
        (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 25 >= y1) && (Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 25 <= y2))*/
