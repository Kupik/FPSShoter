
//using UnityEngine;

//public class WeaponSwitcherGamepad : MonoBehaviour
//{
//    private Item item;

//    public Transform handPosition; // Poziția mainii pentru echiparea armei
//    public Animator animator; // Animator-ul personajului
//    private GameObject currentItem; // Referință la arma curentă echipată
//    //private RaycastFire raycastFire;
//    public GameObject CurrentItem // Getter public
//    {
//        get { return currentItem; }
//    }


//    //private void Start()
//    //{
//    //    // Dezactivează RaycastFire pentru toate armele din scenă
//    //    RaycastFire[] allWeapons = FindObjectsOfType<RaycastFire>();
   

//    //}
//    //private void Update()
//    //{
//    //    if (item != null)
//    //    {
//    //        EquipWeapon(item);        
//    //    }
//    //}

//    //public void EquipWeapon(Item item)
//    //{
//    //    if (item == null)
//    //    {
//    //        Debug.LogError("Item-ul este nul. Nu se poate echipa.");
//    //        return;
//    //    }

  

//    //    if (currentItem != null)
//    //    {
//    //      Destroy(currentItem);
//    //      Destroy(gameObject);
//    //    }


//    //    // Instanțiem și echipăm noua armă
//    //    currentItem = Instantiate(item.prefab_item, handPosition);
//    //    currentItem.transform.localPosition = item.position_offset;
//    //    currentItem.transform.localRotation = Quaternion.Euler(item.rotation_offset);
//    //    currentItem.SetActive(true); // Asigură-te că arma este activată

//    //    // Animațiile specifice pentru arme
//    //    switch (item.itemType)
//    //    {
//    //        case Item.ItemType.AK47:
//    //            PlayAnimation("A_FP_PCH_Idle");
//    //            break;
//    //        case Item.ItemType.Pistol:
//    //            PlayAnimation("A_FP_PCH_Handgun_Idle_Pose");
//    //            break;
//    //        default:
//    //            Debug.LogWarning($"Nu există animație definită pentru {item.itemType}.");
//    //            break;
//    //    }
//    //}



//    //// Redăm animația
//    //private void PlayAnimation(string animationName)
//    //{
//    //    if (!string.IsNullOrEmpty(animationName))
//    //    {
//    //        int animationHash = Animator.StringToHash(animationName);
//    //        animator.Play(animationHash);
//    //        Debug.Log($"Animația Animația {animationName} a fost redată.");
//    //    }
//    //    else
//    //    {
//    //        Debug.LogWarning("Numele animației este gol sau nul.");
//    //    }
//    //}


//    public Item GetEquippedItem()
//    {
//        return item; // Returnează item-ul curent echipat
//    }

//}

