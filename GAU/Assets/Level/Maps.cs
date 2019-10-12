using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour
{
    public GameObject levels, doors;

    public int count = 0;
    public int size = 100;
    bool isclick = false;
    public List<GameObject> level;
    
    void Start()
    {
        int i = 0;
        int way=-2;
        while (i < count - 1)
        {
            if (i == 0)
                add_level(i,out way);
            add_door(level[i],way, out string str, out int pos_x, out int pos_y);
            i += 1;
            add_level(i, out way, str, pos_x, pos_y);
        }
        StartCoroutine(map());          
    }

    IEnumerator map()
    {
        yield return new WaitForSeconds(15f);
        Debug.Log("map");
    }

    void add_level(int i, out int way, string str = "", int pos_x = 1, int pos_y = 1)
    {
        way = -2;
        Vector3 temp_pos = new Vector3(0, 0);
        Vector2 temp_size = getRandomSize(size);
        if (i != 0)
        {
            temp_pos = level[i - 1].GetComponent<RectTransform>().localPosition +
                new Vector3(pos_x * (level[i - 1].GetComponent<RectTransform>().sizeDelta.x + temp_size.x + 20),
                pos_y * (level[i - 1].GetComponent<RectTransform>().sizeDelta.y + temp_size.y + 20)) / 2;
        }
        if (pos_y == 0 && pos_x == -1)
            way = -1;
        else if (pos_y == 1 && pos_x == 0)
            way = 0;
        else if (pos_y == 0 && pos_x == 1)
            way = 1;
        GameObject temp = Instantiate(levels, temp_pos, Quaternion.identity, GetComponent<Transform>());
        temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<RectTransform>().sizeDelta = temp_size;
        temp.name = str + "ID " + i.ToString();
        level.Add(temp);
    }

    void add_door(GameObject level, int way, out string str, out int pos_x, out int pos_y)
    {
        Debug.Log(level.name + "Way= " + way);
        pos_y = pos_x = 0;
        str = level.name;
        var temp = Random.Range(-1, 2);
        var isLoop= true;

        while (isLoop)
            if ((way == -1 && temp == 1) || (way == 1 && temp == -1))
            {
                temp = Random.Range(-1, 2);
                Debug.Log(level.name + "Temp= " + temp);
            }
            else
                isLoop = false;

        switch (temp)
        {
            case -1:
                pos_y = 0;
                pos_x = -1;
                str += " L ";
                break;
            case 0:
                pos_y = 1;
                pos_x = 0;
                str += " T ";
                break;
            case 1:
                pos_y = 0;
                pos_x = 1;
                str += " R ";
                break;
            default:
                Debug.Log("Error");
                break;
        }
        var pos_door = new Vector3(level.GetComponent<RectTransform>().localPosition.x + pos_x * (level.GetComponent<RectTransform>().sizeDelta.x / 2 - 50),
                    level.GetComponent<RectTransform>().localPosition.y + pos_y * (level.GetComponent<RectTransform>().sizeDelta.y / 2 - 50));
        Instantiate(doors, pos_door, Quaternion.identity, level.GetComponent<Transform>()).name = str;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isclick)
        {
            isclick = true;
            Delete();
        }

        if (Input.GetKey(KeyCode.R)&&isclick)
        {
            isclick = false;
            Start();
        }
        if (Input.GetKey(KeyCode.T))
        {
            for (int i = 0; i < count; i++)
            {
                Debug.Log(level[i].name + "|" + level[i].GetComponent<RectTransform>().position + "|" + level[i].GetComponent<RectTransform>().rotation);
            }        
        }

    }

    public Vector2 getRandomSize(float size)
    {
        float x = Random.Range(5, 10);
        float y = Random.Range(5, 10);
        return new Vector2(size * x, size * y);
    }

    public Vector3 getRandomPos(float radius)
    {
        float x = radius * Mathf.Cos(Random.Range(-Mathf.PI, Mathf.PI));
        float y = radius * Mathf.Sin(Random.Range(-Mathf.PI, Mathf.PI));        
        return new Vector3(x, y, 0);
    }

    public void Delete()
    {
        foreach (var go in GameObject.FindGameObjectsWithTag("Level"))
            if (go.layer == LayerMask.NameToLayer("Level"))
            {
                level.Remove(go);
                Destroy(go);
            }

    }
}
