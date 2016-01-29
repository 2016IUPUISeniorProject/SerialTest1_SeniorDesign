using UnityEngine;
using System.Collections;

//the following colors the led in virtual world with a light component i.e (REDLED.enabled), sets a flag i.e. REDLEDSTATUS,
//and calls a function in communicate to serially send the updated information to the real world blinky box

public class CallBlue : MonoBehaviour {
    public static Light BLUELIGHT;
	public static bool BLUELEDSTATUS=false;

	void Start () {
		BLUELIGHT = GetComponent <Light>();
		BLUELIGHT.enabled = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}
	


	void OnMouseDown() {
	 	//print("Clicked");
		BLUELEDSTATUS=!BLUELEDSTATUS;
        if (BLUELEDSTATUS){
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			BLUELIGHT.enabled = true;
		} else {gameObject.GetComponent<Renderer> ().material.color = Color.white;
			BLUELIGHT.enabled = false;}
        if (Communicate.sp.IsOpen) //make sure the port is open before we send
        {
            Communicate.sendBlue(BLUELEDSTATUS);
        }
		//Communicate.sendBlueTEST(BLUELEDSTATUS);
	 }
}
