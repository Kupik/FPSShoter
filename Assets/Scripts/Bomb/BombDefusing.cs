using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BombDefusing : MonoBehaviour
{
    private Dictionary<string, AudioClip> sunteteBomba = new Dictionary<string, AudioClip>();

    public AudioSource audioSource;
    public List<BombAction> soundActions;
    private string currentSounds = null;

    // Disable
    public GameObject LightDisable;

    // Time Bomb
    public float TimerForBomb = 5f;

    private bool bombActive = false;


    // Explosion Bomb
    public GameObject Explosive;

    [Header("Slider BombDefusingProgres")]
    // Defus bomb;
    public GameObject BombDefuseGameObject;
    public Slider SliderDef;
    public float valoareaCurenta = 1f;
    public float valoareaMax = 100f;
    public float vitezaCresteriValori = 10f;
    public GameObject DefuseSliderDeactive;
    [Header("Slider BombDefusingProgres2")]

    private bool SliderIsActive = false; // Verificam slider e activ or nu?
    private bool PlayerRaza = false; // vom verifica daca player e in raza de actiune sau nu e
   



    [System.Serializable]
    public class BombAction
    {
        public string actionName;
        public AudioClip soundClip;
    }


    public void Start()
    {

        audioSource = GetComponent<AudioSource>();

        SliderDef.minValue = 1;
        SliderDef.maxValue = 100;
        SliderDef.value = valoareaCurenta;
  
        BombDefuseGameObject.SetActive(true);
        SliderDef.gameObject.SetActive(false);
        bombActive = true;

        foreach (var action in soundActions)
        {
            sunteteBomba.Add(action.actionName, action.soundClip);
        }

    }

    public void Update()
    {
       

        if(bombActive)
        {
            TimerBob();

        }

        if (PlayerRaza)
        {
            DefuseBomb();
        }

        if (currentSounds != "BombTick")
        {
            PlaySound("BombTick");
            currentSounds = "BombTick";
            Debug.Log("Sunetul Joaca a bombei");
        }


    }
    private void TimerBob()
    {
       


        TimerForBomb -=  Time.deltaTime;

   
        if(TimerForBomb <= 0)
        {

            bombActive = true;
            LightDisable.SetActive(false);
            Explosive.SetActive(true);

        }

    }
    public void DefuseBomb()
    {
        SliderIsActive = !SliderIsActive;
        BombDefuseGameObject.SetActive(true);

        if (SliderIsActive)
        {
            valoareaCurenta += vitezaCresteriValori * Time.deltaTime; // creste Valoarea Curenta
            valoareaCurenta = Mathf.Clamp(valoareaCurenta, 1, valoareaMax);// ma asigur ca ramine inte 1 si 100
            SliderDef.value = valoareaCurenta; // actualizam sliderul sa vedem valoarea la care o ajuns

            if (valoareaCurenta >= valoareaMax)
            {
                SliderIsActive = false;
            }
        }

        if (!PlayerRaza)
        {
            BombDefuseGameObject.SetActive(false);
            valoareaCurenta = 1f;
            SliderDef.value = valoareaCurenta;
        }


        if (TimerForBomb <= 0 )
        {
            BombDefuseGameObject.SetActive(false);
            SliderIsActive = false;
            DefuseSliderDeactive.SetActive(false);
        }

        if (valoareaCurenta == 100)
        {
            // Facem toate obiecte false care sunt legate cu bomba atunic cind valoareaCurenta va fi == 100(doar atunci nu in alt caz)
            Debug.Log("Def Bomb Complet and Off");
            BombDefuseGameObject.SetActive(false);
            SliderDef.gameObject.SetActive(false);
            bombActive = false;
            LightDisable.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ma asigur ca player are tag player
        {

            PlayerRaza = true;
            Debug.Log("Player este in Raza poti defusa");
            SliderDef.gameObject.SetActive(true);

            //if (currentSounds != "BombTick")
            //{
            //    PlaySound("BombTick");
            //    currentSounds = "BombTick";
            //    Debug.Log("Sunetul Joaca a bombei");
            //}


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ma asiguram ca player are tag
        {

            PlayerRaza = false;
            SliderDef.gameObject.SetActive(false);
            SliderIsActive = false;// Oprim slideru când jucătorul iese
            Debug.Log("Player a esit din raza (zona)");
            valoareaCurenta = 1f;
           

        }
    }


    public void PlaySound(string action, float pitch = 1.0f)
    {
        if (sunteteBomba.ContainsKey(action))
        {
            AudioClip clip = sunteteBomba[action];

            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.loop = true; // permite repetarea suntului de mai multe ori
                audioSource.pitch = pitch;
                audioSource.Play();
            }
            else if (!audioSource.isPlaying)
            {
                audioSource.Play(); // daca sunetu e setat il repornim
            }
        }
        else
        {
            Debug.LogWarning("Sunetul pentru actiune nu  a fost gasit");
        }
    }

}
