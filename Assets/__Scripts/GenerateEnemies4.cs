using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies4 : MonoBehaviour
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
        xPos = 754;
        zPos = 185;
        pos.x = xPos;
        pos.y = 0;
        pos.z = zPos;
        pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
        pos.y += 5f;
        Instantiate(Enemy, pos, Enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        xPos = 770;
        zPos = 199;
        pos.x = xPos;
        pos.y = 0;
        pos.z = zPos;
        pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
        pos.y += 5f;
        Instantiate(Enemy, pos, Enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        xPos = 792;
        zPos = 208;
        pos.x = xPos;
        pos.y = 0;
        pos.z = zPos;
        pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
        pos.y += 5f;
        Instantiate(Enemy, pos, Enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        xPos = 818;
        zPos = 214;
        pos.x = xPos;
        pos.y = 0;
        pos.z = zPos;
        pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
        pos.y += 5f;
        Instantiate(Enemy, pos, Enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.1f);
        shown = true;
    }
}
