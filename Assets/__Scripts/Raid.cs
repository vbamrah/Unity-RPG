using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raid : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Boss;
    public int xPos = 0;
    public int zPos = 0;
    public int enemyCount;
    public bool started = false;
    public bool raidWon = false;
    int wave = 1;
    int enemies = 0;
    Vector3 pos = new Vector3(0, 0, 0);

    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI EnemyText;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EnemyDrop());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !started && !raidWon)
        {
            StartCoroutine(startRaid());
        }
    }

    IEnumerator NextWave()
    {
        wave++;
        if (wave == 2)
        {
            enemyCount = 0;
            while (enemyCount < 7)
            {
                xPos = Random.Range(665, 695);
                zPos = Random.Range(388, 416);
                pos.x = xPos;
                pos.y = 0;
                pos.z = zPos;
                pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
                pos.y += 2f;
                Instantiate(Enemy, pos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            StopCoroutine(NextWave());
        }
        else if(wave == 3)
        {
            enemyCount = 0;
            while (enemyCount < 3)
            {
                xPos = Random.Range(665, 695);
                zPos = Random.Range(388, 416);
                pos.x = xPos;
                pos.y = 0;
                pos.z = zPos;
                pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
                pos.y += 2f;
                Instantiate(Enemy, pos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            enemyCount = 0;
            while (enemyCount < 3)
            {
                xPos = Random.Range(580, 600);
                zPos = Random.Range(300, 355);
                pos.x = xPos;
                pos.y = 0;
                pos.z = zPos;
                pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
                pos.y += 2f;
                Instantiate(Enemy2, pos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            StopCoroutine(NextWave());
        }
        else if(wave == 4)
        {
            enemyCount = 0;
            while (enemyCount < 5)
            {
                xPos = Random.Range(665, 695);
                zPos = Random.Range(388, 416);
                pos.x = xPos;
                pos.y = 0;
                pos.z = zPos;
                pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
                pos.y += 2f;
                Instantiate(Enemy, pos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            enemyCount = 0;
            while (enemyCount < 5)
            {
                xPos = Random.Range(580, 600);
                zPos = Random.Range(300, 355);
                pos.x = xPos;
                pos.y = 0;
                pos.z = zPos;
                pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
                pos.y += 2f;
                Instantiate(Enemy2, pos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            StopCoroutine(NextWave());
        }
        else if(wave == 5)
        {
            pos.x = 630;
            pos.z = 374;
            pos.y += 6f;
            Instantiate(Boss, pos, Quaternion.identity);
        }
        else
        {
            started = false;
            raidWon = true;
            EnemyText.text = "";
        }
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Enemy2").Length + GameObject.FindGameObjectsWithTag("Boss").Length;
        if (started && wave !=5 )
        {
            EnemyText.text = "Enemies: " + enemies.ToString();

        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length <= 0 && GameObject.FindGameObjectsWithTag("Boss").Length <= 0 && started)
        {
            WaveText.text = "Raid - Wave: " + (wave +1).ToString();
            StartCoroutine(NextWave());
        }
        if (wave == 5)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            float Health = boss.GetComponent<EnemyHealth>().Health;
            EnemyText.text = "Boss Health: " + Health.ToString();
        }
        if (wave > 5)
        {
            EnemyText.text = "";
            WaveText.text = "Raid Complete!";
        }
    }
    IEnumerator startRaid()
    {
        WaveText.text = "Raid - Wave: " + wave.ToString();
        started = true;
        enemyCount = 0;
        while (enemyCount < 4)
        {
            xPos = Random.Range(580, 600);
            zPos = Random.Range(300, 355);
            pos.x = xPos;
            pos.y = 0;
            pos.z = zPos;
            pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.GetPosition().y;
            pos.y += 2f;
            Instantiate(Enemy, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        StopCoroutine(startRaid());
    }
}
