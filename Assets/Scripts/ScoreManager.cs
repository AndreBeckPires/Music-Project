using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro coinText;
    public  static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }

    public static void Point()
    {
        comboScore++;

    }
    public void addPoint(int i)
    {
        comboScore+=i;
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
       
    }

    public int getScore()
    {
        return  comboScore;
    }
}
