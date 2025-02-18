//using UnityEngine;

//public class WeaponRaycastController : MonoBehaviour
//{
//    private RaycastFire raycastFire;
//    public Transform handPosition;

//    private void Awake()
//    {
//        raycastFire = GetComponent<RaycastFire>();
//        if (raycastFire == null)
//        {
//            Debug.LogError("RaycastFire component missing on " + gameObject.name);
//            return;
//        }

//        // Dezactivează tragerea la început
//        raycastFire.enabled = false;
//    }

//    public void OnPickup()
//    {
//        // Când jucătorul ridică arma, dezactivăm RaycastFire
//        raycastFire.enabled = true ;
//    }

//    public void OnEquip()
//    {
//        // Când arma este echipată și mutată în mână
//        if (IsInHand())
//        {
//            Debug.Log("Arma este echipată și în mână!");
//            raycastFire.enabled = true;
//        }
//        else
//        {
//            Debug.Log("Arma NU este în mână, n u activăm RaycastFire.");
//            raycastFire.enabled = false;
//        }
//    }

//    private bool IsInHand()
//    {
//        return transform.parent == handPosition;
//    }
//}
