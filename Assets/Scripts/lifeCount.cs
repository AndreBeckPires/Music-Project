
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

   void Start(){
      
   }
   public void LoseLife(){
   
     livesRemaining--;
     lives[livesRemaining].enabled = false;

     if(livesRemaining ==0)
     {
         Debug.Log("you lost");
         gameOver.SetActive(true);
         gameOver.GetComponent<gameOver>().setGameIsOver(true);
         
         Destroy(this.gameObject);
         
         
     }
   }


}
