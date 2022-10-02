
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    bool isMoving;
    float timeLeft = 0.5f;
     SpriteRenderer sprite;
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
        isMoving = true;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        
      //  if (t > 1)
      //  {
      //      Destroy(gameObject);
      //  }
       // else
     //   {
        if(isMoving)
        {
           transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t); 
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if(!isMoving)
        {
            timeLeft -= Time.deltaTime;
            this.transform.localScale = new Vector3(this.transform.localScale.x+0.01f, this.transform.localScale.y+0.01f, 0);
            sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a-0.01f); 
            if(timeLeft <= 0)
            Destroy(gameObject);  
        }

      //  }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Line")
        {
            isMoving = false;
            ScoreManager.Point();
        }
    }
}
