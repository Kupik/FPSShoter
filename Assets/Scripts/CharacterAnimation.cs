using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;
    private bool isReloading = false;

    // Nu mai ai nevoie de currentCompareTag fix, vom detecta  arma în mână
    public Transform weaponHolder; 
    public bool isReload = false;

    // input system actions
    private PlayerInput inputAction;

    // move action
    private InputAction reload;
    private InputAction reloadWeaponGamepad;
    


    //daca
    private bool ifPressReload;
    private void Awake()
    {
        inputAction = GetComponent<PlayerInput>();
        reload = inputAction.actions["Reload"];
        reloadWeaponGamepad = inputAction.actions["ReloadGamePad"];
    }

    private void OnEnable()
    {

        
        reload.performed += context => Reload(context);
        reloadWeaponGamepad.performed += context => Reload(context);

        reload.Enable();
        reloadWeaponGamepad.Disable();
    }

    private void OnDisable()
    {

        reload.performed -= context => Reload(context);
        reloadWeaponGamepad.performed -= context => Reload(context);

        reloadWeaponGamepad.Disable();
        reload.Disable();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateRebeindActions();

        if (isReloading)
        {
            return; // Dacă deja se reîncarcă, nu face nimic
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    // detecteaza automat tagul armei curente în mână
        //    string currentWeaponTag = GetCurrentWeaponTag();

        //    if (!string.IsNullOrEmpty(currentWeaponTag)) // daca tag-ul este valid
        //    {
        //        StartCoroutine(ReloadAnimation(currentWeaponTag));
        //    }
        //}
    }

    private void Reload(InputAction.CallbackContext context)
    {

        string getCurrentWeaponTag = GetCurrentWeaponTag();
        if (context.performed)
        {
            StartCoroutine(ReloadWeapon(getCurrentWeaponTag, context));
        }
    }




    // Funcția care detectează tagul armei curente
    string GetCurrentWeaponTag()
    {
        // Presupune arma este un copil al "weaponHolder" (un obiect unde armele sunt atașate)
        foreach (Transform child in weaponHolder)
        {
            if (child.gameObject.activeInHierarchy) 
            {
                return child.tag; // returnează tag-ul armei
            }
        }

        return null; // Nu s-a găsit nicio armă activă
    }

    IEnumerator ReloadWeapon(string weaponTag, InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            Debug.Log("Nui Activ");
            yield break;
        }

        isReload = true;

        GameObject weapon = GameObject.FindGameObjectWithTag(weaponTag);

        if (weapon != null)
        {
            if (weaponTag == "AK")
            {
                animator.SetBool("ReloadWP", true);
                Debug.Log("Reloading AK...");
                yield return new WaitForSeconds(0.25f);
                animator.SetBool("ReloadWP", false);
            }
            else if (weaponTag == "ShootGun")
            {
                animator.SetBool("GunReload", true);
                Debug.Log("Reloading Shotgun...");
                yield return new WaitForSeconds(0.25f);
                animator.SetBool("GunReload", false);

            }
            else if (weaponTag == "HandGun")
            {
                //animator.SetBool("Reload", true);
                animator.SetBool("HandgunR", true);
                Debug.Log("Reload   HandGun");
                yield return new WaitForSeconds(0.25f);
                animator.SetBool("HandgunR", false);
                ///animator.SetBool("Reload", false);

            }
        }
    }

    public void OnEjectCasing()
    {
        // functie pentru animati
    }


    public void OnAmmunitionFill()
    {

        Debug.Log("completată.");
    }

    public void OnAnimationEndedReload()
    {

    }

   
    private void UpdateRebeindActions()
    {
        ifPressReload = reload.WasPerformedThisFrame();

        ifPressReload = reloadWeaponGamepad.WasPerformedThisFrame();
    }
}
