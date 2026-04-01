using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
    public void UpdateScore(int ponints)
    {
        score += ponints;
        scoreText.text = "Score: " + score;
    }
}
