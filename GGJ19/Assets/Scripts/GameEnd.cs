using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [HideInInspector] public bool gameEnded;
    [SerializeField] private Text outroText;
    [SerializeField] private Text leftSummary;
    [SerializeField] private Text rightSummary;
    [SerializeField] private AudioClip victoryJingle;
    private Camera camera;
    private Side right;
    private Side left;
    private House house;
    private PlayerPlatformerController leftPlayer;
    private PlayerPlatformerController rightPlayer;
    private float victoryAngle = 20.0f;

    void Start()
    {
        gameEnded = false;
        camera = FindObjectOfType<Camera>();
        house = FindObjectOfType<House>();
        foreach(PlayerPlatformerController player in FindObjectsOfType<PlayerPlatformerController>())
        {
            if (player.name == "PlayerOne")
                leftPlayer = player;
            else
                rightPlayer = player;
        }
        foreach (Side side in FindObjectsOfType<Side>())
        {
            if (side.name.ToLower().Contains("left"))
                left = side;
            else
                right = side;
        }
    }
 
    void Update()
    {
        if (gameEnded && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            CheckGameEnd();
        }
    }

    private void CheckGameEnd()
    {
        float zAngle = house.transform.eulerAngles.z;
        if (zAngle >= victoryAngle && zAngle <= 360.0f - victoryAngle)
        {
            EndGame(zAngle);
        }
    }

    private void EndGame(float zAngle)
    {
        if (gameEnded)
            return;
        gameEnded = true;
        camera.GetComponent<AudioSource>().clip = victoryJingle;
        camera.GetComponent<AudioSource>().Play();
        camera.GetComponent<AudioSource>().loop = false;

        string restart = "\n\nPress SPACE to Restart";
        if (zAngle <= 180.0f)
        {
            outroText.text = "Right player wins!" + restart;
        }
        else if (zAngle > 180.0f)
        {
            outroText.text = "Left player wins!" + restart;
        }
        rightSummary.text = "Threw " + rightPlayer.throwCounter.ToString() + " item(s)";
        leftSummary.text = "Threw " + leftPlayer.throwCounter.ToString() + " item(s)";
    }
}
