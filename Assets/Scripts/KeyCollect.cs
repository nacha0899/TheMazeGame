using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public GameObject door;
    public GameObject Global;
    void OnTriggerEnter(Collider other) 
    {
        Global.GetComponent<GameLogic>().gotTheKey();
        Destroy(door);
        Destroy(this.gameObject, 1);


    }
}
