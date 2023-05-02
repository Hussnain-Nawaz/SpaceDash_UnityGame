using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValuesScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Countdown.points = 0;
        Countdown.currentTime = 0f;
        CheckpointSpawn.checkLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
