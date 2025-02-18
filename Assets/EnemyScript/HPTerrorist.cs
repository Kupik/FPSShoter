using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTerrorist : MonoBehaviour
{
   public int HP = 100;
    public GameObject enemy;
    private int currentHealth;



    private void Start()
    {
        HP = 100;
    }

    //public void Update()
    //{
        
    //}


    public void TakeDamageTerrorist(int damage)
    {
    HP -= damage;
        if( HP <= 0)
        {
            Debug.Log("Terrorist Dead and Destroy");
            // GameObject.Destroy(gameObject);//va distruge pe terorist
            enemy.SetActive(false);
             currentHealth = 0;

        }
    }

    public int GetCurrentHealthTerrorist()
    {
        return HP; // Returnează HP curent
    }
}
