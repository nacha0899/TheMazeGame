using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    // Racer X (Runner)
    public GameObject RacerX;

    //Animator Parameter to trigger animations
    private Animator _anim;
    private Animator _Ganim;

    //boolean to confirm collision
    public bool collision;

    //Loser AudioSource
    public AudioSource _announcer;
    public AudioClip _announcement;

    //boolean that lets the audio only play after one collision detect
    private bool hasPlayed;

    public GameObject _GameOverPanel;

    void OnTriggerEnter(Collider other)
    {
        var racerX = GameObject.Find("Pac Racer X");
        var ghost = GameObject.FindGameObjectsWithTag("Ghosts");
         foreach(GameObject g in ghost) {
            if (other.name == "Pac Racer X")
            {
                _Ganim = g.GetComponent<Animator>();
                _Ganim.ResetTrigger("chase");
                _Ganim.SetTrigger("Eaten");
                collision = true;

                _anim = racerX.GetComponent<Animator>();
                _anim.SetBool("Collision", collision);
                _GameOverPanel.SetActive(true);
                racerX.GetComponent<Movement>().enabled = false;

                if (!hasPlayed)
                {
                    _announcer.PlayOneShot(_announcement);
                    hasPlayed = true;
                }

            }
         
            
            

        }

        
        


    }


}
