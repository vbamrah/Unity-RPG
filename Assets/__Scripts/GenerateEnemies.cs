using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos = 0;
    public int zPos = 0 ;
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
        while (enemyCount < 5)
        {
            xPos = Random.Range(859, 864);
            zPos = Random.Range(31, 75);
            pos.x = xPos;
            pos.y = 0;
            pos.z = zPos;
            pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
            pos.y += 2f;
            Instantiate(Enemy, pos , Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        shown = true;
    }
}
