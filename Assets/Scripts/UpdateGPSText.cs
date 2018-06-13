using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {

    public Text Coordinates;
	
	// Update is called once per frame
	void Update () {
        Coordinates.text = "Latitude: " + GPS.Instance.latitude.ToString() + "   Longitude: " + GPS.Instance.longitude.ToString() + "Altitude: " + GPS.Instance.altitude.ToString() + "Horizon: " + GPS.Instance.horizon.ToString() + "Vertical: " + GPS.Instance.vertical.ToString() + "Rotation: " + GPS.Instance.rotation.ToString();
	}
}
