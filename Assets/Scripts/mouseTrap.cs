using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseTrap : MonoBehaviour
{

    private bool isSet;
    // Start is called before the first frame update
    void Start()
    {
        isSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getSet() {
        isSet = true;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void hit() {
        isSet = false;
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
