using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float totalTime = 5f; // total time to count down from
    public TextMeshProUGUI timerText; // reference to the text field displaying the timer
    static public float currentTime; // current time remaining
    public TextMeshProUGUI scoreText;
    static public int points;
    public GameObject Prefab;
    public GameObject UIObject;
    public GameObject Spaceship;
    static public GameObject finalPrefab;
    public GameObject Prefab2;
    static public GameObject finalPrefab2;
    public GameObject display;
    static public GameObject finalPrefab3;
    public GameObject prefab3;
    public GameObject UIDisplay;
    static public GameObject LastUi;
    static public bool Gameover = false;
    void Start()
    {
        LastUi = UIDisplay;
        finalPrefab = Prefab;
        finalPrefab2 = Prefab2;
        finalPrefab3 = prefab3;
        currentTime = totalTime;
    }

    void Update()
    {
        if (!Gameover)
        {
            if (!display.activeInHierarchy)
            {
                if (currentTime == 0.00)
                {
                    Spaceship.SetActive(false);
                    UIObject.SetActive(true);
                }
                // update the timer
                currentTime -= Time.deltaTime;

                // check if the timer has reached zero
                if (currentTime <= 0f)
                {
                    currentTime = 0f;
                    // do something when the timer reaches zero
                    Debug.Log("Time's up!");
                }

                // update the text field
                timerText.text = currentTime.ToString("F2"); // "F2" formats the float to display two decimal places
                scoreText.text = points.ToString();
            }
        }
    }
}
