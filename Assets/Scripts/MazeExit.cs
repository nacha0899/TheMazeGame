using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class MazeExit : MonoBehaviour
{
    public GameObject _player;
    public GameObject _winnerScreen;

    public AudioSource _announcer;
    public AudioClip _winnerAudio;

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Pac Racer X")
        {
            _announcer.PlayOneShot(_winnerAudio);
            _winnerScreen.SetActive(true);
            _player.GetComponent<Movement>().enabled = false;
            //_player.GetComponent<Playeridle>().enabled = true;

        }

    }

    private void OnTriggerExit()
    {


    }

}
