using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheckPoint : MonoBehaviour
{
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        canvas = GameObject.Find("Healing circle(Clone)");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Countdown.currentTime = 0f;
            canvas.SetActive(false);
            Countdown.Gameover = true;
            Countdown.LastUi.SetActive(true);
            ResetValueLvl3.spaceship.SetActive(false);

        }
    }
}
