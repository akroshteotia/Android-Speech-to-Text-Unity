using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using MiniJSON;
using System.Collections.Generic;

public class ExampleScript : MonoBehaviour {

    public Text uiText;
    IList<object> result;
    // Use this for initialization
    void Start () {
        ListnerManager._instance.resultCallBack = OnRecievedResult;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnRecievedResult(string audioOutput)
    {
        result = MiniJSON.Json.Deserialize(audioOutput) as IList<object>;
        string[] answer = result.Cast<string>().ToArray();
        Debug.Log(answer);
        //answer will return an arry of words... those are similar to your word 
        // i am taking only first word.. you can check array in log if there any
        uiText.text = "";
        foreach (string voice in answer)
            uiText.text += voice + "\t";
    }

    public void BtnStartSpeech()
    {
        Debug.Log("start");
        ListnerManager._instance.StartSpeech();
        
    }

    public void BtnStopSpeech()
    {
        Debug.Log("stop");
        ListnerManager._instance.StopSpeech();
    }

    
}
