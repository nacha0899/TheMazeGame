using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearInstructions : MonoBehaviour
{    //Sound and Audio Variables
    public AudioSource audioSource;
    public AudioClip introClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hear() 
    {
        audioSource.Play();
    
}
}
