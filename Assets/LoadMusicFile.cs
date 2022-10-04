using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;

public class LoadMusicFile : MonoBehaviour
{
    public AudioClip clip;
    string path;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OpenFileBrowser()
    {
        path = EditorUtility.OpenFilePanel("Select your music", "ogg", "ogg");
        StartCoroutine(GetAudio());
    }
    IEnumerator GetAudio()

    {

        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path,AudioType.OGGVORBIS);
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
           clip = ((DownloadHandlerAudioClip)www.downloadHandler).audioClip;
        }
    }


}
