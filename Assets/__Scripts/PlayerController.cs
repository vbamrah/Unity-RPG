using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int count;
    public int level;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI levelText;
    public bool inShop = false;
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;

    public TextMeshProUGUI levelUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;   //Setting initial count value to 0
        level = 1;
        SetCountText();
        SetLevelText();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);

    }

    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();
    }

    void SetLevelText()
    {
        levelText.text = "Level: " + level.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Chest"))
        {

            other.transform.parent.gameObject.SetActive(false);
            count = count + 50;
            SetCountText();
        }
        if (other.gameObject.CompareTag("levelUp"))
        {
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            TakeDamage(15);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            TakeDamage(25);
        }
        if (other.gameObject.CompareTag("Border") && level < 2)
        {
            level++;
            SetLevelText();
        }
    }

    // Update is called once per frame
   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
    }
    void Update()
    {
        SetCountText();
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene");
            print("Dead");
        }
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
