//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DefuseBomb : MonoBehaviour
//{
//    // Slider
//    public Slider defuseSlider;
//    public float valoareaCurenta = 1f;
//    public float valoareaMaxima = 100f;
//    public float VitezaDeCrestere = 10f;

//    public bool isActiveSlider = false; // Verificam slider e activ?

//    private void Start()
//    {
//        defuseSlider.minValue = 1;
//        defuseSlider.maxValue = 100;
//        defuseSlider.value = valoareaCurenta;
//    }


//    private void Update()
//    {


//        if(Input.GetKeyDown(KeyCode.E))
//        {
//            isActiveSlider = !isActiveSlider;
//        }

//        if(isActiveSlider)
//        {
//            valoareaCurenta += VitezaDeCrestere * Time.deltaTime; // Crestem valoarea Curenta
//            valoareaCurenta = Mathf.Clamp(valoareaCurenta, 1, valoareaMaxima); // ne asiguram ca ramine intre 1 si 100
//            defuseSlider.value = valoareaCurenta; // Actualizam Slideru

//            if(valoareaCurenta >= valoareaMaxima)
//            {
//                isActiveSlider = false;
//            }
//        }
//    }



//}
