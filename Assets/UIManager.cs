using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager S;
    public Text pointsText;

    void Awake()
    {
        S = this;    
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void UpdatePointsText(int points) {
        pointsText.text = "Points: " + points;
    }

}
