
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    bool isMoving;
    float timeLeft = 0.6f;
    public Vector3 dir;
    public GameObject particle;
     SpriteRenderer sprite;
    void Start()
    {
        isMoving = true;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.position += dir * Time.deltaTime;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if(!isMoving)
        {
            timeLeft -= Time.deltaTime;
            this.transform.localScale = new Vector3(this.transform.localScale.x+0.01f, this.transform.localScale.y+0.01f, 0);
            sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a-0.03f); 
            if(timeLeft <= 0)
            Destroy(this.gameObject);  
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Line")
        {
            isMoving = false;
            ScoreManager.Point();
        }
    }

    public void ParticleDestroy()
    {
        Instantiate(particle, transform.position, Quaternion.identity);


        Destroy(gameObject);
    }
}
