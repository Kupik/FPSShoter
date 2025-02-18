using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
   
    public static PlayerHealth Instance;
    public int health = 2;
    public int maxHealth = 100; // max health
    public Slider slider;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        health = 20;
    }


    private void Update()
    {
        slider.value = health;
    }

    public void TakeDamage(int healthpoint)
    {
        health -= healthpoint;
        if (health <= 0)
        {
            // die
            Debug.Log("you have 0 hp");
            health = 0;
        }
    }

  

    public void Heal(int healthpoint)
    {
        health += healthpoint;
        slider.value = health;
    }


    public int GetCurrentHealth()
    {
        return health;
    }



}
