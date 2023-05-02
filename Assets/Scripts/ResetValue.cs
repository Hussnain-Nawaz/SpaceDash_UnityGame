using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValue : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject spaceship1;
    static public GameObject canvas;
    static public GameObject spaceship;
    // Start is called before the first frame update
    void Start()
    {
        canvas = canvas1;
        spaceship = spaceship1;
        Countdown.points = 0;
        Countdown.currentTime = 0f;
        CheckpointSpawn.checkLevel = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
