using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At_Cam : MonoBehaviour
{
    [SerializeField] Transform cam;
    public void LateUpdate()
    {
        transform.LookAt(cam.position);
    }
}
