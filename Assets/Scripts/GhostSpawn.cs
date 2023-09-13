using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public AudioSource _announcer;
    public AudioClip _announcement;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
       

        if (other.name == "Pac Racer X") 
        {

        _announcer.PlayOneShot(_announcement);

            var ghost = GameObject.FindGameObjectsWithTag("Ghosts");
            
            foreach(GameObject g in ghost) 
            {
               g.GetComponent<GhostLogic>().enabled = true;
            }
        }
    }
}
