
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    private PlayerInput playerInput;
    private InputAction pick_up;
    private bool is_near_player; // vom verifica da playerul este aproape de item
    public bool isnear // Getter public
    {
        get { return is_near_player; }
    }

    private void Awake()
    {


        playerInput = GetComponent<PlayerInput>();
        pick_up = playerInput.actions["PickUp"];

        
    }

    private void OnEnable()
    {
        pick_up.performed += OnPickUpPerformed;
        pick_up.Enable();
    }

    private void OnDisable()
    {
        pick_up.performed -= OnPickUpPerformed;
        pick_up.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            is_near_player = true;
            Debug.Log("Press F.");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            is_near_player = false;
            Debug.Log("A esit din zona");

        }
    }

    private void OnPickUpPerformed(InputAction.CallbackContext context)
    {
        if (is_near_player)
        {
            PickUp();
        }
    }

    private void PickUp()
    {

        if (item.isUsed)
        {
            Debug.Log("Item-    ul a fost deja folosit nu poate fi ridicat.");
            return;
        }

        if (!item.canUsed)
        {
            Debug.Log("nu poate fi marcat ca folosit.");
            return;
        }


        InventorySystem.Instance.Add(item); // Adauga itemul(Copia)
        Debug.Log($"{item.name} picked up!");
        Destroy(gameObject);

    }

    public void UseItem()
    {

        switch (item.itemType)
        {
            case Item.ItemType.Regen:
                PlayerHealth.Instance.Heal(item.healthpoint);
                Debug.Log("Use you Regen");
                item.isUsed = false; // Item folosit
                item.canUsed = true;
                RemoveItemPickUp();
                break;
        }
    }
    public void RemoveItemPickUp()
    {
        InventorySystem.Instance.Remove(item);
    }

}