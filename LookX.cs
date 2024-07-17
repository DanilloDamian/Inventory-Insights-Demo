using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{

    [SerializeField]
    private float sensitivity = 1f;

    void Start()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * sensitivity;
        
        transform.localEulerAngles = newRotation;
    }
}
