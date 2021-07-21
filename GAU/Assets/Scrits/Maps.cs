using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class write : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame updatet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        Delete();
    }


    public Vector2 getRandomSize(float size)
    {
        float rnd=Random.Range(1,10);
        float x=2*Mathf.PI*rnd;
        float y = rnd + Random.Range(10, 20);
        return new Vector2(size * x, size * y);
    }

    public Vector3 getRandomPos(float radius)
    {
        float rnd = Random.Range(1, 10);
        float x = Mathf.PI * rnd*Mathf.Cos(radius);
        float y = Mathf.PI * rnd*Mathf.Sin(radius);

        return new Vector3(radius * x, radius * y, 0);
    }
    public void Generation(int y)
    {
        for (int i = 0; i < y; i++)
        {
            GameObject go = Instantiate(level,getRandomPos(Random.Range(1,10))+ new Vector3(400, 240, 0), Quaternion.identity, GetComponent<Transform>());
            go.GetComponent<BoxCollider2D>().size = go.GetComponent<RectTransform>().sizeDelta = getRandomSize(10);
            go.name = "ID " + i.ToString();
        }

    }
    public void Delete()
    {
        foreach (var go in GameObject.FindGameObjectsWithTag("Level"))
            Destroy(go);
      
    }
}
