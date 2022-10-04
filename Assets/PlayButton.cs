using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private LoadMusicFile musicFile;
    // Start is called before the first frame update
    void Awake()
    {
        musicFile = GameObject.Find("LoadFile").GetComponent<LoadMusicFile>();

    }

    // Update is called once per frame
    void Update()
    {
        if(musicFile.clip == null)
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Button>().enabled  = true;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
