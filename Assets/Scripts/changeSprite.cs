

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{

    public Material newMaterial;
    public SpriteRenderer meshRenderer;
    public  Material oldMaterial;
    float timeLeft = 1.1f;
    bool collision = false;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SpriteRenderer>();
        oldMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(collision)
        {

            timeLeft-=Time.deltaTime;
            if(timeLeft>0.7f)
            {
               meshRenderer.material = newMaterial;
            }
            if(timeLeft<=0.7f)
            {
               meshRenderer.material = oldMaterial;
                  collision = false;
            } 
        }
        if(!collision)
            {
                timeLeft = 1.0f;
            }
    }

      void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note" && gameObject.GetComponent<PlayerController>().canTakeDamage)
        {
            collision = true;
        }
    }
}
