using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{

	//character controller being utilized to simplify movement coding
	public CharacterController characterController;

	//Camera obj of player, Mouse controls the transform os this object by rotating it
	public Transform camMove;

	//rigidbody component to manipulate for jumping and other player movement (will apply force upwards)
	public Rigidbody rigidbod;

	//Box collider of the runner for slide animation
	public BoxCollider Collider;

	//constant speed variables
	public float runnspeed;
	public float turnspeed;

	//private float grav;// gravity variable to prevent physics from conflicting with character

	public Vector3 _axis;

	// jumping  variables to determine whether runner is on ground,  on the air, or concluding the jump cycle
	//public bool groundContact = true;//determines whether the player is touching the ground or not to prevent extra space hits (no double jumping)

	//Gameover screen: Will check if knocked down animation is in play and display Game over screen:
	public GameObject _gameOverScreen;

	//instance of collision detector from Canonball
	public GameObject _canonball;


	//key inputs
	[SerializeField] private KeyCode _jumpKey;
	[SerializeField] private KeyCode _slideKey;


	//Sound and Audio Variables
	public AudioSource audioSource;
	public AudioClip _slideSound;

	//public AudioSource _announcer;
	//public AudioClip _intro;
	
	

	//Animator Parameter to trigger animations
	private Animator _anim;

	void Start()
	{
		_anim = GetComponent<Animator>();

	


	}


	void MovementUpdate()
	{
		//constant gravity variable
		//grav -= 2*(Physics.gravity.y * Time.deltaTime);

		// Gets axis 
		_axis.x = Input.GetAxis("Horizontal");
		_axis.y = Input.GetAxis("Vertical");


		//sets the variables for the animator controller
		_anim.SetFloat("v", _axis.y);
		_anim.SetFloat("h", _axis.x);

		//retrieves vector input
		Vector3 direction = new Vector3(_axis.x, 0f, _axis.y).normalized;

		// if input thresh hold passes 0 then character will move via using the character controller

		if (direction.magnitude >= 0.1)
		{

			//using Atan function to indicate where player should be facing depending on Key input on y axis Like pacman from a birds eye view
			//Use https://allenchou.net/2019/10/inverse-trig/ for guidance.

			float turnAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camMove.eulerAngles.y;

			//Euler from Week 4/5
			transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);


			//character speed setto 50f when running 
			runnspeed = 20f;
			Vector3 movementDirect = Quaternion.Euler(0f, turnAngle, 0f) * Vector3.forward;
			characterController.Move(movementDirect.normalized * runnspeed * Time.deltaTime);


			if (Input.GetKey(_slideKey))
			{
				StartCoroutine(AnimationDelay());
				_anim.SetTrigger("Slide/attack");

				//audioSource.PlayOneShot(_slideSound);
				this.transform.Translate(Vector3.forward * Time.deltaTime * 10, Space.World);
				rigidbod.AddForce(new Vector3(0, -20f, 0), ForceMode.Impulse);

				Collider.size = new Vector3(1, 0.6f, 1);

				audioSource.PlayOneShot(_slideSound);
			

              



            }




		}

		//jumping updated from midterm asgn using force application rather than velocity WILL FIX JUMPING ON FINAL 
		//if (Input.GetKey(_jumpKey))
		//{
		//
		//	
		//	rigidbod.AddForce(new Vector3(0, 20f, 0), ForceMode.Impulse);
		//
		//	
		//}



	}

	// Update is called once per frame
	void Update()
	{


        if (_canonball.GetComponent<HitDetect>().collision == true)
        {
            Console.WriteLine("HIT!");
			// will actiate game over screen
            _gameOverScreen.SetActive(true);
        }
        MovementUpdate();

	}

	// Collision listener that changes variable to true as long as there is ground contact
	//private void OnCollissionEnter(Collision collision) 
	//{
	//	if(collision.gameObject.tag=="Floor")
	//		groundContact= true;
	//}


	IEnumerator AnimationDelay()
	{
		Console.WriteLine("Sliding");
		yield return new WaitForSeconds(1.5f);
		Collider.size = new Vector3(0.5943385f, 1.777092f, 1);
	}
}
