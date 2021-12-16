using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 25f;
    GameObject refObj = GameObject.Find("Raid");
    public GameObject gold;
    Raid script;

    private void Start()
    {
        script = refObj.GetComponent<Raid>();
    }

    public void TakeDamage(float amnt)
    {
        Health -= amnt;
        if (Health <= 0)
        {
            Instantiate(gold, gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject);
            print("Enemy has Died!");
        }

        print("Enemy took damage");
    }
    public float getHealth()
    {
        return Health;
    }
}