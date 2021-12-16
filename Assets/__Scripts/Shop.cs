using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shop : MonoBehaviour
{
    private GameObject shop;
    public bool inShop;
    int coins;
    int HealthPotionCount;
    GameObject player;
    GameObject axe;
    GameObject crossbow;
    public TextMeshProUGUI HealthPotionText;
    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.Find("Shop");
        shop.SetActive(false);
        player = GameObject.Find("FPSController");
        HealthPotionCount = 0;
        axe = GameObject.Find("axe");
        crossbow = GameObject.Find("Crossbow");
    }

    // Update is called once per frame
    void Update()
    {
        HealthPotionText.text = "Health Potions: " + HealthPotionCount.ToString();
        coins = player.GetComponent<PlayerController>().count;
        if (inShop)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                buyPotion();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                buyAxeUpgrade();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                buyBowUpgrade();
            }
        }
        if (!inShop)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && HealthPotionCount > 0)
            {
                HealthPotionCount--;
                int max = player.GetComponent<PlayerController>().maxHealth;
                int current = player.GetComponent<PlayerController>().currentHealth;
                if (max - current < 50)
                {
                    player.GetComponent<PlayerController>().currentHealth = max;
                }
                else
                {
                    player.GetComponent<PlayerController>().TakeDamage(-50);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.tag == "MainCamera")
            {
                shop.SetActive(true);
                inShop = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "MainCamera")
            {
                shop.SetActive(false);
                inShop = false;
            }
        }

        void buyPotion()
        {
            if (coins >= 50)
            {
                coins -= 50;
                player.GetComponent<PlayerController>().count = coins;
                HealthPotionCount++;
            }
        }

        void buyAxeUpgrade()
        {
            if (coins >= 100)
            {
                coins -= 100;
                player.GetComponent<PlayerController>().count = coins;
                axe.GetComponent<Weapon>().attackDamage += 5;
            }
        }
        void buyBowUpgrade()
        {
            if (coins >= 150)
            {
                coins -= 150;
                player.GetComponent<PlayerController>().count = coins;
                crossbow.GetComponent<Weapon>().attackDamage += 5;
            }
        }
    }