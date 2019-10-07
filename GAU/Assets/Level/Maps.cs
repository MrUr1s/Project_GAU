using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour
{
    public GameObject levels;

    public int count = 0;
    public int size = 100;
    bool isclick = false;
    GameObject[] temp;

    void Start()
    {
        temp = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            Vector3 temp_pos = new Vector3(0,0);
            if (i!=0)
                temp_pos = temp[i-1].GetComponent<RectTransform>().localPosition;
            temp[i] = Instantiate(levels, temp_pos + getRandomPos(size*2), Quaternion.identity, GetComponent<Transform>());
            temp[i].GetComponent<BoxCollider2D>().size = temp[i].GetComponent<RectTransform>().sizeDelta = getRandomSize(size);
            temp[i].name = "ID " + i.ToString();
        }
        StartCoroutine(map());
    }

    IEnumerator map()
    {
        yield return new WaitForSeconds(15f);
        Debug.Log("map");
    }

    void FixedUpdate()
    {

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
                Debug.Log(temp[i].name);
                Debug.Log(temp[i].GetComponent<RectTransform>().position);
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
            if(go.layer==LayerMask.NameToLayer("Level"))
        Destroy(go);

    }
}
