using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject Hand;
    public GameObject axe;
    public GameObject crossbow;
    public Weapon myWeapon;
    public Weapon myWeapon2;
    public GameObject projectile;
    public GameObject arrowSpawn;

    Animator handAnim;
    
    private float attackTimer;
    private float weaponNum = 1f;

    void Start()
    {
        handAnim = axe.GetComponent<Animator>();
        myWeapon = Hand.GetComponentInChildren<Weapon>();
        axe.SetActive(true);
        crossbow.SetActive(false);
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (weaponNum == 1)
        {
            axe.SetActive(true);
            crossbow.SetActive(false);
            if (Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCooldown)
            {
                attackTimer = 0f;
                handAnim.Play("AxeAnimation");
                DoAttack();
            }
        }
        else if (weaponNum == -1)
        {
            axe.SetActive(false);
            crossbow.SetActive(true);
            if (Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCooldown)
            {
                attackTimer = 0f;
                //handAnim.Play("AxeAnimation");
                DoAttack2();
            }
        }

        if (Input.GetKeyUp("r"))
        {
            weaponNum = weaponNum * (-1);
        }
    }
    private void DoAttack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, myWeapon.attackDamage))
        {
            if(hit.collider.tag == "Enemy" || hit.collider.tag == "Enemy2" || hit.collider.tag == "Boss")
            {
                EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
                eHealth.TakeDamage(myWeapon.attackDamage);
            }
        }
    }
    private void DoAttack2()
    {
        GameObject arrow;
        arrow = Instantiate(projectile, arrowSpawn.transform.position, arrowSpawn.transform.rotation);
    }
}