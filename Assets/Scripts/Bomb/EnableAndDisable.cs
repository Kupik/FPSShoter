using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisable : MonoBehaviour
{
    public Light ligth;

    private void Start()
    {
        InvokeRepeating("LampEnableAndDisamble", 0f, 1f);


    }


    private void LampEnableAndDisamble()
    {
        ligth.enabled = !ligth.enabled;
    }



}
