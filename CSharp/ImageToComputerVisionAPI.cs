using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

public class ImageToComputerVisionAPI : MonoBehaviour {

    string VISIONKEY = ""; // replace with your Computer Vision API Key

    string emotionURL = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";

    public string fileName { get; private set; }
    string responseData;

    // Use this for initialization
    void Start () {
	    fileName = Path.Combine(Application.streamingAssetsPath, "trash.jpg");
    }
	
	// Update is called once per frame
	void Update () {
	
        // This will be called with your specific input mechanism
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetVisionDataFromImages());
        }

	}
    /// <summary>
    /// Get emotion data from the Cognitive Services Emotion API
    /// Stores the response into the responseData string
    /// </summary>
    /// <returns> IEnumerator - needs to be called in a Coroutine </returns>
    IEnumerator GetVisionDataFromImages()
    {
        //byte[] bytes = UnityEngine.Windows.File.ReadAllBytes(fileName);

       
        string bytes = "https://c8.alamy.com/comp/BDR0JF/an-overflowing-trash-can-is-seen-on-the-streets-of-the-chelsea-neighborhood-BDR0JF.jpg";
        byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(bytes);
        var headers = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", VISIONKEY },
            { "Content-Type", "application/octet-stream" }
        };

        WWW www = new WWW(emotionURL, utf8Bytes, headers);

        yield return www;
        responseData = www.text; // Save the response as JSON string
        GetComponent<ParseComputerVisionResponse>().ParseJSONData(responseData);
    }
}
