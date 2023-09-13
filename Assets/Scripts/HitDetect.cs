using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
	// Racer X (Runner)
	public GameObject RacerX;

    //Animator Parameter to trigger animations
    private Animator _anim;

	//boolean to confirm collision
	public bool collision;

    //Game Over Screen Instance;
   // public GameObject _GameOverPanel;

    //Sound and Audio Variables
    public AudioSource audioSource;
	public AudioClip _collisionSound;



	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Pac Racer X")
		{
			collision = true;
			var racerX = GameObject.Find("Pac Racer X");
			//GameObject end = GameObject.Find("Canvas/GameOver");
			//end.SetActive(true);
			//_GameOverPanel.SetActive(true);
            _anim = racerX.GetComponent<Animator>();
			_anim.SetBool("Collision", collision);
           
            audioSource.PlayOneShot(_collisionSound);

			
			//gets collider for this game obj and disables after first collision
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			// disables Movement script in order to prevent any movement and end the game
			racerX.GetComponent<Movement>().enabled = false;

			
		}
	}
}
