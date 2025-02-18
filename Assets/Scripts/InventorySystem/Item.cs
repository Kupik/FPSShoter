using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item" , menuName= " Item/Create new Item")]
public class Item : ScriptableObject //din ce va fi creat item
{

   
    public int id; // id 

    public string name_item; // numele
    public Sprite icon_item;// image
    public bool fireWeapon = false;
  
    public GameObject prefab_item; // prefab item
    public string idle_animation;  // animatie item (pentru arme)
    public string weapon_tag;      // tag arme (posibil)
    public ItemType itemType;      // vom indentifica itemType pentru itemu-rile noastre
    public Vector3 position_offset = Vector3.zero; // Offset pentru pozitie
    public Vector3 rotation_offset = Vector3.zero; // Offset personalizat pentru rotație
    public int healthpoint;
    public bool isUsed = false;
    public bool canUsed = true;
    public bool isActive = false;



    // Aici sunt itemTypurile
    public enum ItemType
    {
        Pistol,
        AK47,
        ShotGun,
        Regen,
        Throw,
        Weapon,
    }



}
