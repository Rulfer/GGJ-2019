using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private Text introText;

    PlayerPlatformerController[] players;

    private void Awake()
    {
        players = GameObject.FindObjectsOfType<PlayerPlatformerController>();

        for (int i = 0; i < players.Length; i++)
            players[i].enabled = false;
    }

    private void Three()
    {
        introText.text = "3";
    }

    private void Two()
    {
        introText.text = "2";
    }

    private void One()
    {
        introText.text = "1";
    }

    private void Go()
    {
        introText.text = "GO!";
        this.GetComponent<Animator>().StopPlayback();

        for (int i = 0; i < players.Length; i++)
            players[i].enabled = true;
    }

    private void RemoveText()
    {
        introText.text = "";
    }
}
