using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalAnimator : MonoBehaviour {

    public AudioSource source;
    public static float[] samples;
    //public static float[] freqBand;
    public float sizeMultiplier;

    public GameObject level;

    private void Awake()
    {
        //source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        source.volume = 0.65f;
        samples = new float[512];
        //freqBand = new float[8];
    }

    // Update is called once per frame
    void Update () {
        GetSpectrumAudioSource();
        //MakeFrecuencyBands();
        foreach (GameObject tree in level.GetComponent<LevelGenerator>().trees)
        {
            tree.transform.localScale = Vector3.one * Average() * sizeMultiplier;
        }

    }

    float Average()
    {
        var sum = 0f;
        for (int i = 0; i < samples.Length; i++)
            sum += samples[i];
        return sum / samples.Length;
    }

    void GetSpectrumAudioSource()
    {
        source.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
    //void MakeFrecuencyBands()
    //{
    //    int count = 0;
    //    for (int i = 0; i < 8; i++)
    //    {
    //        float average = 0;
    //        int sampleCount = (int)Mathf.Pow(2, i) * 2;
    //        if (i == 7)
    //        {
    //            sampleCount += 2;
    //        }
    //        for (int j = 0; j < sampleCount; j++)
    //        {
    //            average += samples[count] * (count + 1);
    //            count++;
    //        }
    //        average /= count;

    //        freqBand[i] = average * 10;
    //    }
    //}
}
