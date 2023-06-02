using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class AudioVisualiser : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBands= new float[8];
    public static float[] _bandBuffer= new float[8];
    float[] _bufferDecrease = new float[8];

    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];
    float[] _frequencyBandHighest = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        getSpectrumFromAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if(_freqBands[i] > _frequencyBandHighest[i])
            {
                _frequencyBandHighest[i] = _freqBands[i];

            }
            _audioBand[i] = (_freqBands[i] / _frequencyBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _frequencyBandHighest[i]);


        }
    }

    void getSpectrumFromAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if(_freqBands[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBands[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBands[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i< 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j ++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBands[i] = average * 10;
        }
    }
}
