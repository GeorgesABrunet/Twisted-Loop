using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PostGameStats : MonoBehaviour
{
    public static int Jumps = 0;
    public static int Smacks = 0;

    public static Text PostGame;
    void Start()
    {
        GameObject PGStats = GameObject.Find("PostGameStats");
        PostGame = PGStats.GetComponent<Text>();
    }

    void Update()
    {
        PostGame.text = "Jumps: " + Jumps.ToString() + "  Smacks: " + Smacks.ToString();
    }
}
