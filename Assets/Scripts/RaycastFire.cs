using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RaycastFire : MonoBehaviour
{
    private Dictionary<string, AudioClip> suneteActiuni = new Dictionary<string, AudioClip>();


    public AudioSource audioSource;
    private PlayerInput inputActions;

    public float range = 100f;
    public Camera fpsCam;
    public Animator animator;

    // Particle system
    public ParticleSystem Muzzle;
    public GameObject impact;


    // Viteza reload
    private float reload = 1.5f;
    private bool isReloading = false;

    // bulltet ammo firerate
    private float fireRate = 15f;
    public float fireTimeToRate = 0f;

    public int BulletWP = 30;
    public int CureentBullet; // nr de patroane la moment in arma;
    public int AmmoPack = 270;


    // Damage
    public int damage = 20;

    //if ground or no
    private bool isGround;
    private bool isWeaponPickedUp = false;

    public AudioClip fireSound; // Sunet pentru arma
    public AudioClip reloadSouns;

    // actions
    private InputAction FireW;
    private InputAction FireGamePad;
    private InputAction ReloadW;
    private InputAction ReloadGamepad;


    private RaycastFire raycastFire;

    private void Awake()
    {
        raycastFire = GetComponent<RaycastFire>();
        raycastFire.enabled = false;

        fpsCam = Camera.main;
        inputActions = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();

        
        FireW = inputActions.actions["Fire"];
        FireGamePad = inputActions.actions["GamePadFire"];

        ReloadW = inputActions.actions["Reload"];
        ReloadGamepad = inputActions.actions["ReloadGamePad"];

      
    }
    private void OnEnable()
    {
        FireW.performed += Fire;
        FireGamePad.performed += Fire;


        ReloadW.performed += Reload;
        ReloadGamepad.performed += Reload;



        ReloadGamepad.Enable();
        ReloadW.Enable();

        FireW.Enable();
        FireGamePad.Enable();
    }

    private void OnDisable()
    {
        FireW.canceled -= Fire;
        FireGamePad.canceled -= Fire;

        ReloadW.canceled -= Reload;
        ReloadGamepad.canceled -= Reload;

        ReloadGamepad.Disable();
        ReloadW.Disable();

        FireW.Disable();
        FireGamePad.Disable();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        CureentBullet = BulletWP;
        
    }


    private void Update()
    {

        if (isWeaponPickedUp)
        {
            RefacereCamera();
        }
       

    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (isReloading || CureentBullet <= 0)
            
            return;

        if (Time.time >= fireTimeToRate)
        {
            fireTimeToRate = Time.time + 1f / fireRate;
            StartCoroutine(Shoot());
        }
    }


    private void Reload(InputAction.CallbackContext context)
    {

        if (!isReloading && AmmoPack > 0 && CureentBullet < BulletWP)
        {
            Debug.Log("Contex ReloadWeapon RaycastFire File");
            StartCoroutine(ReloadWP());
        }
    }

    IEnumerator ReloadWP()
    {
        isReloading = true;
        animator.SetBool("Reload", true);
        audioSource.PlayOneShot(reloadSouns);
        Debug.Log("Reload WP1");
        yield return new WaitForSeconds(reload);


        int BulletsReload = BulletWP - CureentBullet;

        int ReloadWeapon = Mathf.Min(BulletsReload, AmmoPack);
        CureentBullet += ReloadWeapon;
        AmmoPack -= ReloadWeapon;


        animator.SetBool("Reload", false);
        isReloading = false;

    }

  public IEnumerator Shoot()
    {

        animator.SetBool("Fire", true);
        audioSource.PlayOneShot(fireSound);
        yield return new WaitForSeconds(0.25f);
        Muzzle.Play();
        CureentBullet--;

        Debug.Log("Fire Bullet");
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            HPTerrorist hpT = hit.transform.GetComponent<HPTerrorist>();
            if (hpT != null)
            {
                hpT.TakeDamageTerrorist(damage);// aplicam dmg
                animator.SetBool("Fire", true);

            }
            if (impact != null)
            {
                GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
        animator.SetBool("Fire", false);
    }

    public void OnAmmunitionFill()
    {
        Debug.Log("Ammunition refilled.");
    }

    public void OnAnimationEndedReload()
    {
    }
    private void RefacereCamera()
    {
                Vector3 cameraPosition = new Vector3(fpsCam.transform.position.x, fpsCam.transform.position.y, fpsCam.transform.position.z);

        fpsCam.transform.position = Vector3.Lerp(fpsCam.transform.position, cameraPosition, Time.deltaTime * 5f);  // ajustam viteza dupa necesitate
    }


  

}
