using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies2 : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos = 0;
    public int zPos = 0;
    public int enemyCount;
    bool shown = false;
    Vector3 pos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EnemyDrop());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !shown)
        {
            shown = true;
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            xPos = Random.Range(921, 951);
            zPos = Random.Range(130, 140);
            pos.x = xPos;
            pos.y = 0;
            pos.z = zPos;
            pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
            pos.y += 25f;
            Instantiate(Enemy, pos, Enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            //Instantiate(Enemy, new Vector3(0,0,0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        shown = true;
    }
}
