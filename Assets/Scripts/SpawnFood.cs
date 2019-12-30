using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform borderTop;
    [SerializeField] private Transform borderBottom;
    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    private void Spawn()
    {
        if (GameObject.Find(foodPrefab.transform.name))
        {
            return;
        }

        var x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        var y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        var go = Instantiate<GameObject>(foodPrefab, new Vector2(x, y), Quaternion.identity);
        go.transform.name = foodPrefab.transform.name;
    }
}
