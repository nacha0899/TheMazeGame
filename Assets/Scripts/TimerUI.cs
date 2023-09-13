using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimerUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
	public float timeleft=180f;
	public static TimerUI Instance;
	public GameObject _GameOverPanel;
	public GameObject _playerMovement;
	public bool timeWork = true;
	public AudioSource _audioSource;
    public AudioClip _timeUp;
	public AudioClip _minuteLeft;
	public AudioClip _halfMinuteLeft;
	private bool timeUpPlayed = false;
	private bool timeMinutePlayed = false;
	private bool timeHalfMinutePlayed = false;




    // Start is called before the first frame update
    void Start()
    {
		if (Instance == null) { Instance = this; }

		else { Destroy(this.gameObject); }


	}

	public void updateTime(float currentTime)
	{
		if(timeleft>=currentTime && timeWork==true ) 
		{
            currentTime += 1;
            float seconds = Mathf.FloorToInt(currentTime % 180);
            _text.text = "Time Left " + seconds.ToString() + " seconds";

            timeleft -= Time.deltaTime;

        }

		if (timeleft <= 60 && timeMinutePlayed == false)
		{
            timeMinutePlayed = true;
            var globe = GameObject.Find("GLOBAL");
            _audioSource = globe.GetComponent<AudioSource>();
            _audioSource.PlayOneShot(_minuteLeft);
        }

		if (timeleft <= 30 && timeHalfMinutePlayed == false) 
		{
            timeHalfMinutePlayed = true;
            var globe = GameObject.Find("GLOBAL");
            _audioSource = globe.GetComponent<AudioSource>();
            _audioSource.PlayOneShot(_halfMinuteLeft);
        }
		

        if (timeleft <= 0)
        {
			timeWork = false;
			timeleft = 0;
			_text.text = "Time Left 0 Seconds";
			_playerMovement.GetComponent<Movement>().enabled=false;
            _GameOverPanel.SetActive(true);

            if (timeUpPlayed == false) {
				timeUpPlayed = true;
                var globe = GameObject.Find("GLOBAL");
                _audioSource = globe.GetComponent<AudioSource>();
                _audioSource.PlayOneShot(_timeUp);
            }
        }
    }

	//public void TLogicUpdate() 
	//{
	//	timeleft -= Time.deltaTime;
	//
	//	if (timeleft == 0)
	//	{
	//
	//		_text.text = "Game Over";
	//		_GameOverPanel.SetActive(true);
	//	}
	//}

	// Update is called once per frame
	void Update()
	{

		updateTime(timeleft);
		//TLogicUpdate();

		
	}
}
