using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLogic : MonoBehaviour
{

    public GameObject cball;
    public float launchVel = 200f;
    private float nextShot = 0f;
    private float inBetween = 4f;

    // canon shot SFX
	public AudioSource audioSource;
	public AudioClip _boomSound;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextShot)
        {
            //Shoots every 7 seconds
            nextShot=Time.time+ inBetween;

            GameObject ball = Instantiate(cball, transform.position, transform.rotation);
            //audioSource.PlayOneShot(_boomSound);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(launchVel, 0, 0));
            Destroy(ball, 7f);
        }
    }
}
