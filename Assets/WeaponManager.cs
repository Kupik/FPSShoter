//using UnityEngine;

//public class WeaponManager : MonoBehaviour
//{
//    public Transform playerHand;  // Referință la locul unde se ține arma
//    private GameObject currentWeapon; // Arma echipată

//    public void EquipWeapon(GameObject newWeaponPrefab)
//    {

//        if (newWeaponPrefab == null)
//        {
//            Debug.LogError("EquipWeapon: Arma nouă este NULL!");
//            return;
//        }

//        if (currentWeapon != null)
//        {
//            Destroy(currentWeapon);
//            currentWeapon = null;  // 🔥 Evită referințele vechi
//        }

//        // Instanțiem noua armă în mâna jucătorului
//        currentWeapon = Instantiate(newWeaponPrefab, playerHand.position, playerHand.rotation);
//        currentWeapon.transform.SetParent(playerHand);

//        // Resetăm poziția și rotația pentru a se alinia corect
//        currentWeapon.transform.localPosition = Vector3.zero;
//        currentWeapon.transform.localRotation = Quaternion.identity;

//        // Activăm RaycastFire pentru arma nouă
//        RaycastFire weaponRaycast = currentWeapon.GetComponent<RaycastFire>();
//        if (weaponRaycast != null)
//        {
//            weaponRaycast.enabled = true;
//        }
//        else
//        {
//            Debug.LogError("Arma echipată nu are RaycastFire!");
//        }

//        Debug.Log("Arma echipată corect: " + newWeaponPrefab.name);
//    }
//}
