using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode2 : MonoBehaviour
{

    public float mousesensityvityX=100f;
    public float mousesensityvityY=100f;

    float xRotation=0f;

    public Transform Camera;
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxis("Mouse X") * mousesensityvityX * Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y") * mousesensityvityY * Time.deltaTime;
        
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        Camera.Rotate(Vector3.up * mouseX);
        
   
    }
}
