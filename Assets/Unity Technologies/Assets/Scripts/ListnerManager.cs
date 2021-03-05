using UnityEngine;


public class ListnerManager : MonoBehaviour
{
    public static ListnerManager _instance;
    public System.Action<string> resultCallBack;
    public void Result(string dataReceived)
    {
        Debug.Log(dataReceived);
        if (resultCallBack != null)
        {
            resultCallBack(dataReceived);
            Debug.Log("result");
        }
    }

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log(_instance);
    }
  
  
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass javaClass = new AndroidJavaClass("com.voice.plugin.UnityBridge"))
        {
            javaClass.CallStatic("Init");
            Debug.Log("Init()");
        }
#endif
    }

    public void StartSpeech()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // This function calling Java Code from Jar file to start android Speech Service
        using (AndroidJavaClass javaClass = new AndroidJavaClass("com.voice.plugin.UnityBridge"))
        {
            javaClass.CallStatic("StartSpeech");
        }
#endif
    }

    public void StopSpeech()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // This function calling Java Code from Jar file to start android stop Service
        using (AndroidJavaClass javaClass = new AndroidJavaClass("com.voice.plugin.UnityBridge"))
        {
            javaClass.CallStatic("StopSpeech");
        }
#endif
    }
}