using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRoatate : MonoBehaviour
{
    private float rotSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0, Space.World);
    }
}
