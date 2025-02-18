using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraRotation : MonoBehaviour
{
    public Transform cameraTransform; // Referință către camera personajului

    void Update()
    {
        // Obținem rotația pe axa Y a camerei (stânga-dreapta)
       // Vector3 cameraRotation = cameraTransform.eulerAngles;

        // Aplicăm rotația pe axa Y pentru corpul jucătorului astfel încât să urmeze rotația camerei
        //transform.eulerAngles = new Vector3(0, cameraRotation.y, 0);
    }
}
