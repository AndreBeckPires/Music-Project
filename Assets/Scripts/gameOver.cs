using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointsText;
    public GameObject obj;
    public bool gamerIsOver = false;
    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = obj.GetComponent<ScoreManager>().getScore().ToString();
    }
    void Update(){
        if(gamerIsOver)
         pointsText.text = obj.GetComponent<ScoreManager>().getScore().ToString();
    }



     
    public void setGameIsOver(bool isOver){
        gamerIsOver  = isOver;
    }
}
