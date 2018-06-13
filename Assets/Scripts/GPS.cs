using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
    public float altitude;
    public float horizon;
    public float vertical;
    public Quaternion rotation;


	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
        
	}
	
	// Update is called once per frame
	void Update () {

        getUpdatedData();
	}


    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;

        }

        Input.compass.enabled = true;
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;

        }

        if (maxWait<=0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;

        }



        yield break;


    }

    private void getUpdatedData()
    {

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        altitude = Input.location.lastData.altitude;
        horizon = Input.location.lastData.horizontalAccuracy;
        vertical = Input.location.lastData.verticalAccuracy;
        rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
    }



}
