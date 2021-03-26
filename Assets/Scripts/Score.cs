using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text Scoreboard;
    public GameObject ball;

    public static bool canAddScore = true;

    private int leftScore = 0;
    private int rightScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x >= 20f && canAddScore)
        {
            canAddScore = false;
            leftScore++;
        }
        if (ball.transform.position.x <= -20f && canAddScore)
        {
            canAddScore = false;
            rightScore++;
        }

        if(leftScore >= 3)
        {
            SceneManager.LoadScene(2);
        }
        if (rightScore >= 3)
        {
            SceneManager.LoadScene(3);
        }


        Scoreboard.text = leftScore.ToString() + " - " + rightScore.ToString();

        print(leftScore + " , " + rightScore);
    }
}
