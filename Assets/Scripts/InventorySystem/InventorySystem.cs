using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance; // pentru a crea item nostru;
    public List<Item> Items = new List<Item>(); // crearea unei noi instante goale

    private Item item;
    public Transform handPosition;
    public GameObject currentItem;
    public Animator animator;

    public Transform ItemContent; // Continutul Obiectului
    public GameObject InventoryItem; // Our Inventory

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems; // array[] unidimensional

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Va fi distrus");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item); // adaugare
    }

    public void Remove(Item remove)
    {
        Items.Remove(remove); // stergere
    }

    public void ListItems()
    {
        

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("name_item").GetComponent<Text>();
            var itemIcon = obj.transform.Find("icon_name").GetComponent<Image>();
            var removeButton = obj.transform.Find("remove_button").GetComponent<Button>();
            var dropButton = obj.transform.Find("drop_button").GetComponent<Button>();
            var equipButton = obj.transform.Find("equip_button").GetComponent<Button>();

            itemName.text = item.name_item;
            itemIcon.sprite = item.icon_item;

            var inventoryItemController = obj.GetComponent<InventoryItemController>();
            inventoryItemController.AddItem(item);

            dropButton.onClick.AddListener(() => inventoryItemController.DropItem());
            equipButton.onClick.AddListener(() => EquipWeapon(item)); // Conectare funcție echipare

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
        SetInventoryItems();
    }

    public void EquipWeapon(Item item)
    {
        if (item == null || item.prefab_item == null)
        {
            Debug.LogError("EquipWeapon: Item sau prefab-ul este NULL!");
            return;
        }

        // Distrugem aram curenta de ai echipa alta (aleasa);
        if (currentItem != null)
        {
            Destroy(currentItem);
            currentItem = null;
        }

        //Instantiem o arama nou (Adica ii face o copie aremei ce a fost ridicata) Instatiem face copia item-mului adica (Prefabului)
        currentItem = Instantiate(item.prefab_item, handPosition);
        currentItem.transform.SetParent(handPosition);
        currentItem.transform.localPosition = item.position_offset;
        currentItem.transform.localRotation = Quaternion.Euler(item.rotation_offset);


        // Activam raycastul daca el este pe arama(Script)
        RaycastFire weaponRaycast = currentItem.GetComponent<RaycastFire>();
        if (weaponRaycast != null)
        {
            weaponRaycast.enabled = true;
        }
        else
        {
            Debug.LogError("Arma echipată nu are RaycastFire!");
        }

        switch (item.itemType)
        {
            case Item.ItemType.Regen:
                PlayerHealth.Instance.Heal(item.healthpoint);
                Debug.Log("Ai folosit un item de regenerare!");
                item.isUsed = false;
                Remove(item);
                break;

            case Item.ItemType.AK47:
            case Item.ItemType.Pistol:
            case Item.ItemType.ShotGun:
                string idleAnimation = item.itemType == Item.ItemType.Pistol ?
                    "A_FP_PCH_Handgun_Idle_Pose" : "A_FP_PCH_Idle";
                PlayAnimation(idleAnimation);
                break;

            default:
                Debug.LogWarning($"Nu este animatie {item.itemType}.");
                break;
        }

        Debug.Log($"Arma echipata: {item.name_item}, pozitia: {item.position_offset}, rotatie: {item.rotation_offset}.");
    }



    private void PlayAnimation(string animationName)
    {
        if (!string.IsNullOrEmpty(animationName))
        {
            int animationHash = Animator.StringToHash(animationName);
            animator.Play(animationHash);
            Debug.Log($"animatia {animationName} a fost redata.");
        }
        else
        {
            Debug.LogWarning("Numele animatie este Gol sau NUll.");
        }
    }
    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
