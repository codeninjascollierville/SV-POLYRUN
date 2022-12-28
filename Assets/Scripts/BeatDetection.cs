using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatDetection : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform[] spawnPoints;
    public GameObject shapes1, shapes2;
    public GameObject[] turretShapes;
    public int randomSpawnPoint, randomTurrets;

    private float[] historyBuffer = new float[64];
    private float[] channelLeft = new float[64];
    private float[] channelRight = new float[64];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //compute instant sound energy
        audioSource.GetSpectrumData(channelLeft, 0, FFTWindow.Blackman);
        audioSource.GetSpectrumData(channelRight, 0, FFTWindow.Blackman);

        float e = sumStereo(channelLeft, channelRight);

        //compute local average sound evergy
        float E = sumLocalEnergy() / historyBuffer.Length; // E being the average local sound energy

        //calculate variance
        float sumV = 0;
        for (int i = 0; i < 43; i++)
            sumV += (historyBuffer[i] - E) * (historyBuffer[i] - E);

        float V = sumV / historyBuffer.Length;
        float constant = (float)((-0.0025714 * V) + 1.5142857);
        float constant2 = (float)((-0.0025714 * V) + 0.5142857);
        float constant3 = (float)((-0.0025714 * V) + 0.1);

        float[] shiftingHistoryBuffer = new float[historyBuffer.Length]; // make a new array and copy all the values to it

        for (int i = 0; i < (historyBuffer.Length - 1); i++)
        { // now we shift the array one slot to the right
            shiftingHistoryBuffer[i + 1] = historyBuffer[i]; // and fill the empty slot with the new instant sound energy
        }

        shiftingHistoryBuffer[0] = e;

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            historyBuffer[i] = shiftingHistoryBuffer[i]; //then we return the values to the original array
        }

        //float constant = 1.5f;

        if (e > (constant * E))
        { // now we check if we have a beat
            Debug.Log("No Beat!");
        }
        if (e < (constant * E))
        {
            Debug.Log("Low Beat!");
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(shapes1, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);

        }
        if (e < (constant2 * E))
        {
            Debug.Log("Med Beat!");
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(shapes2, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        }
        if (e < (constant3 * E))
        {
            Debug.Log("High Beat!");
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(turretShapes[randomTurrets], spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        }
    }

    float sumStereo(float[] channel1, float[] channel2)
    {
        float e = 0;
        for (int i = 0; i < channel1.Length; i++)
        {
            e += ((channel1[i] * channel1[i]) + (channel2[i] * channel2[i]));
        }

        return e;
    }

    float sumLocalEnergy()
    {
        float E = 0;

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            E += historyBuffer[i] * historyBuffer[i];
        }

        return E;
    }

    string historybuffer()
    {
        string s = "";
        for (int i = 0; i < historyBuffer.Length; i++)
        {
            s += (historyBuffer[i] + ",");
        }
        return s;
    }
}