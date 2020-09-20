using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Cheese : MonoBehaviour
{

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cam = GameObject.Find("Main Camera");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * 7 * Time.deltaTime);
        cam.transform.position = GameObject.Find("Player").transform.position;
        transform.Rotate(0, Input.GetAxis("Mouse X") * 70 * Time.deltaTime, 0, Space.Self);
        cam.transform.Rotate(0, Input.GetAxis("Mouse X") * 70 * Time.deltaTime, 0, Space.Self);
    }
}
