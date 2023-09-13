using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeridle : MonoBehaviour
{
    //Animator Parameter to trigger animations
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
            

    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetTrigger("Idle");
    }
}
