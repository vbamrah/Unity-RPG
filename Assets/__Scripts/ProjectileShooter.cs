using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    Rigidbody m_rigidbody;

    void Start()
    {
        //GameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag != "MainCamera")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Boss")
        {
            EnemyHealth eHealth = collision.gameObject.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(50);
        }
    }

}
