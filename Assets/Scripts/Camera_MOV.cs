using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Camera_Shake))]
public class Camera_MOV : MonoBehaviour
{
    [Header("Rot rest")]
    [SerializeField] float u_rot_lim, d_rot_lim;
    public float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    [SerializeField] float L_Lim, R_Lim;
    [SerializeField] float F_Lim, B_Lim;
    bool is_mov = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            is_mov = !is_mov;
        }
        if (!is_mov) { return;}
        if (Input.GetMouseButton(1))
        {
            Mosue();
        }
        lastMouse = Input.mousePosition;
        if (is_mov)
        {
            float f = 0.0f;
            Vector3 p = GetBaseInput();
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }


    }

    private void Mosue()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, 0, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, 0, 0);
        float clamp_x = Mathf.Clamp(lastMouse.x,u_rot_lim,d_rot_lim);
        float clamp_y = lastMouse.y;
        float clamp_z = lastMouse.z;
        transform.eulerAngles = new Vector3(clamp_x,clamp_y,clamp_z);


    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W) && transform.position.z <= F_Lim)
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z >= B_Lim)
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= L_Lim)
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= R_Lim)
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
