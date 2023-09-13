using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI _text;
	//public GameObject _WinnerPanel;
	public int scoredisp;
	

	


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		scoredisp = GameLogic.Instance.Score;

		
		_text.text = "Score: " + scoredisp;

	

	}
}
