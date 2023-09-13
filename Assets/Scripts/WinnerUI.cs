using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    public int scoredisp;
  

    // Update is called once per frame
    void Update()
    {
        scoredisp = GameLogic.Instance.Score;
        _text.text = "Congratulations! You made it out with " + scoredisp + " points!";
    }
}
