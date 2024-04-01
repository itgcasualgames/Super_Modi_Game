using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {
	public void Start () {
        GetComponent<Camera>().aspect = 1920f / 1080f;
        Screen.SetResolution(1920, 1080, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
	}
}