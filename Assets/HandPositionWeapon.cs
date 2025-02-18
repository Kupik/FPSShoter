//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HandPositionWeapon : MonoBehaviour
//{
//    public static HandPositionWeapon instance;
//    public GameObject currentWeapon; // Arma curentă în mână

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    public void EquipWeapon(GameObject newWeapon)
//    {
//        // Dezactivează arma veche dacă există
//        if (currentWeapon != null)
//        {
//            currentWeapon.SetActive(false);
//        }

//        // Activează noua armă și o setează ca activă
//        currentWeapon = newWeapon;
//        currentWeapon.SetActive(true);
//    }

//    public bool HasWeaponEquipped()
//    {
//        return currentWeapon != null;
//    }
//}


