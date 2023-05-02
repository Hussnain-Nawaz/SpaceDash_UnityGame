using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValueLvl3 : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas3;
    public GameObject spaceship1;
    static public GameObject canvas;
    static public GameObject spaceship;
    static public GameObject canvas2;
    // Start is called before the first frame update
    void Start()
    {
        canvas2 = canvas3;
        canvas = canvas1;
        spaceship = spaceship1;
        Countdown.points = 0;
        Countdown.currentTime = 0f;
        CheckpointSpawn.checkLevel = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
