using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{

    [SerializeField]
    private float sensitivity = 1f;

    void Start()
    {

    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += mouseY * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
