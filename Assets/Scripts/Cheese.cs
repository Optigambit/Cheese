using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private bool settingTrap;
    private string trapName;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settingTrap = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cam = GameObject.Find("Main Camera");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * 7 * Time.deltaTime);
        controller.Move(new Vector3(0, -9.81f * Time.deltaTime, 0));
        cam.transform.position = GameObject.Find("Player").transform.position;
        transform.Rotate(0, Input.GetAxis("Mouse X") * 70 * Time.deltaTime, 0, Space.Self);
        cam.transform.Rotate(0, Input.GetAxis("Mouse X") * 70 * Time.deltaTime, 0, Space.Self);
        if (Input.GetKeyDown(KeyCode.Mouse0) && settingTrap) {
            GameObject.Find(trapName).GetComponent<mouseTrap>().getSet();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("trap")) {
            settingTrap = true;
            trapName = collision.gameObject.name;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag.Equals("trap")) {
            settingTrap = false;
        }
    }
}
