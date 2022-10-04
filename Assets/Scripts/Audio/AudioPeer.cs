using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent (typeof (AudioSource)) ]
public class AudioPeer : MonoBehaviour
{
    AudioSource audioSource;

    public static float[] samples = new float[512];
    public static float[] freqBand  = new float[8];

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GameObject.Find("LoadFile").GetComponent<LoadMusicFile>().clip;

    }
    void Start()
    {
        if(audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0,FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        for(int i = 0;i< 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j< 8; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }        
            average /= sampleCount;

            freqBand[i] = average * 10;
        }
    }
}
