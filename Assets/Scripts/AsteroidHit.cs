using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (CheckpointSpawn.checkLevel==2)
            {
                Countdown.Gameover = true;
                ResetValue.spaceship.SetActive(false);
                ResetValue.canvas.SetActive(true);
            }
            else if(CheckpointSpawn.checkLevel==3)
            {
                Countdown.Gameover = true;
                ResetValueLvl3.spaceship.SetActive(false);
                ResetValueLvl3.canvas.SetActive(true);
            }
        }
    }
}
