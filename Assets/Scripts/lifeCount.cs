
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class lifeCount : MonoBehaviour
{
    // Start is called before the first frame update
   public Image[] lives;
   public int livesRemaining;
   public GameObject gameOver;
   public GameObject pointsCounter;


   void Start(){
      
   }
   void Update(){
    Debug.Log(livesRemaining);
   }
   public void LoseLife(){
   
     livesRemaining--;
     lives[livesRemaining].enabled = false;

     if(livesRemaining ==0)
     {
         Debug.Log("you lost");
         gameOver.SetActive(true);
         gameOver.GetComponent<gameOver>().setGameIsOver(true);
         pointsCounter.SetActive(false);
         Destroy(this.gameObject);
         
         
     }
   }
   public void addLife(){
    
      if(livesRemaining < 4)
      {  
      livesRemaining++;
      if(lives[0].enabled == false)
      lives[0].enabled = true;
      else if(lives[1].enabled == false)
      lives[1].enabled = true;
      else if(lives[2].enabled == false)
      lives[2].enabled = true;
      else if(lives[3].enabled == false)
      lives[3].enabled = true;

      }
    
   }


}
