using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovementScript : MonoBehaviour
{
    public Transform target;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
    }
}
