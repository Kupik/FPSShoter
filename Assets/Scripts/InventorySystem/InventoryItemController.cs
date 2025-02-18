
using UnityEngine;
using UnityEngine.UI;



public class InventoryItemController : MonoBehaviour
{
    private static InventorySystem inventorySystem;
    private Item item;
    public Button remove_button;
    public Button equiped;
    public bool isDropping = false;


    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }


    public void AddItem(Item newItem)
    {
        item = newItem;

        equiped.onClick.AddListener(() => InventorySystem.Instance.EquipWeapon(item));
        item.prefab_item.SetActive(true);
    }




    public void DropItem()
    {
        if (isDropping || item == null)
        {
            //Debug.LogError("Item-ul este deja proces de aruncare sau este NULL.");
            return;
        }

        isDropping = true; // sa efectuat drop-ul

        // Scoatem item-ul din inventar inainte de al distruge
        if (inventorySystem != null)
        {
            inventorySystem.Remove(item);
        }

        Transform playerTransform = Camera.main.transform;
        Vector3 dropPosition = playerTransform.position
                               + playerTransform.forward * 2f
                               + Vector3.up * 1f;

        if (item.prefab_item != null)
        {
            GameObject droppedItem = Instantiate(item.prefab_item, dropPosition, Quaternion.identity);

            Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            Collider collider = droppedItem.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = false;
            }

            droppedItem.AddComponent<ItemDropHandler>();
        }
        else
        {
            Debug.LogError("Prefab-ul item-ului este NULL!");
        }

// Disrugem obiectuk din inventari UI dar sai Ramna in mina arama
        Destroy(gameObject);
    }


    public void UseItem()
    {
        if (!item.canUsed)
        {
            Debug.Log("Nu poate fi folosit.");
            return;
        }

        if (item.isUsed)
        {
            Debug.Log("Iemul a fost deja folosit si deja nu mai este posibil sal ridici.");
            return;
        }

        switch (item.itemType)
        {
            case Item.ItemType.Regen:
                PlayerHealth.Instance.Heal(item.healthpoint);
                Debug.Log("Use you Regen");
                item.isUsed = true;
                RemoveItem();
                //inventorySystem.Remove(item);
                
                break;

            case Item.ItemType.AK47:
            case Item.ItemType.Pistol:
            case Item.ItemType.ShotGun:
                if (inventorySystem != null)
                {
                    Debug.Log("Echipare arma: " + item.prefab_item.name);
                    inventorySystem.EquipWeapon(item);
                }
                break;


        }


    }

    public void RemoveItem()
    {
        InventorySystem.Instance.Remove(item);
        Destroy(gameObject);
        Debug.Log("Itemul a fost distrus");
    }

}


