using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class smoothcamera : MonoBehaviour {


    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float offsetx = 0f; // Смещение по x.
    public float offsety = 0f; // Смещение по y.
    public GameObject fps;

    GUIStyle style = new GUIStyle();
    int accumulator = 0;
    int counter = 0;
    float timer = 0f;
    // Use this for initialization
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x + offsetx, target.position.y + 0.75f + offsety, target.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
    void Update()
    {
        accumulator++;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            fps.GetComponent<Text>().text ="FPS "+ accumulator.ToString();
            accumulator = 0;
        }
    }
}
