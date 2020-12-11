using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public static int Lols = 0;
    public static Text LolsThisGame;
    void Start()
    {
        GameObject DisplayLols = GameObject.Find("DisplayStats");
        LolsThisGame = DisplayLols.GetComponent<Text>();
    }
    void Update()
    {
        LolsThisGame.text = "Lmoa: " + Lols.ToString();
    }
}
