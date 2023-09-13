using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	// Start is called before the first frame update

	public static GameLogic Instance;
	public int Score;

	//audio for point counter
    public AudioSource _announcer;
    public AudioClip _points100;
    public AudioClip _points200;
    public AudioClip _points300;
	public AudioClip _gotKey;
	public AudioClip _minute;
	public AudioClip _timeUp;
	//public boolean to make sure they only play once
	public bool hasPlayed100=false;
	public bool hasPlayed200=false;
	public bool hasPlayed300=false;
	public bool hasPlayedKey=false;

    void Start()
	{
		if (Instance == null) { Instance = this; }

		else { Destroy(this.gameObject); }
	}


	// Update is called once per frame
	void Update()
	{
		if (Score>=100 && hasPlayed100==false)
		{
			_announcer.PlayOneShot(_points100);
			hasPlayed100= true;
		}

        if (Score >= 200 && hasPlayed200 == false)
        {
            _announcer.PlayOneShot(_points200);
            hasPlayed200 = true;
        }

        if (Score >= 300 && hasPlayed300 == false)
        {
            _announcer.PlayOneShot(_points300);
            hasPlayed300 = true;
        }
    }


	public void gotTheKey() 
	{
		_announcer.PlayOneShot(_gotKey);
	}


}
