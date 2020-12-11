using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int Lives = 3;
    public static Text LivesLeft;
    void Start()
    {
        GameObject DisplayLives = GameObject.Find("DisplayLives");
        LivesLeft = DisplayLives.GetComponent<Text>();
    }
    void Update()
    {
        LivesLeft.text = "Lives: " + Lives.ToString();
    }
}
