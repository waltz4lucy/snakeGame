using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;
    private Vector2 dir = Vector2.up;
    private List<Transform> tail = new List<Transform>();
    private bool isEat = false;

    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.1f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && dir != -Vector2.up)
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && dir != -Vector2.right)
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
        {
            dir = -Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
        {
            dir = -Vector2.right;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.StartsWith("foodPrefab"))
        {
            isEat = true;
            Destroy(col.gameObject);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (isEat)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            isEat = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
