using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0; // static, accessible anywhere
    public TMP_Text scoreText;    // drag your UI Text here

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
