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
    private Side right;
    private Side left;
    private House house;
    private float victoryAngle = 20.0f;

    void Start()
    {
        gameEnded = false;
        house = FindObjectOfType<House>();
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
        string restart = "\n\nPress Space to Restart";
        if (zAngle <= 180.0f)
        {
            outroText.text = "Right player wins!" + restart;
        }
        else if (zAngle > 180.0f)
        {
            outroText.text = "Left player wins!" + restart;
        }
        rightSummary.text = "Threw " + right.leaveCounter + " element(s)\nHas " + right.elementsInside.Count + " element(s).";
        leftSummary.text = "Threw " + left.leaveCounter + " element(s)\nHas " + left.elementsInside.Count + " element(s).";
    }
}
