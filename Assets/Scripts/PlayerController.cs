
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
     bool collision;
    // Start is called before the first frame update
    [SerializeField]
    private Tilemap groundTileMap;
    [SerializeField]
    private Tilemap collisionTileMap;
    private PlayerMovement controls;
    public GameObject pointsController;
    float coins = 0;
    public bool canTakeDamage = true;
    private float damageTimer = .1f;
     public TMPro.TextMeshPro coinText;


    private void Awake(){
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        collision = false;
    }

    void Update(){
         coinText.text = coins.ToString();

        if (!canTakeDamage)
        {
            damageTimer -= Time.deltaTime;
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
            if (damageTimer <= 0)
            {
                canTakeDamage = true;
            }
        }
        else
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp; 
            damageTimer = .1f;
        }
     }
        
    

    private void Move(Vector2 direction){
        if(CanMove(direction))
        {
            canTakeDamage = false;
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction){
        Vector3Int gridPosition = groundTileMap.WorldToCell(transform.position +(Vector3)direction);
        if(!groundTileMap.HasTile(gridPosition) || collisionTileMap.HasTile(gridPosition))
            return false;
        return true;
    }
    // Update is called once per frame
    
      void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note" && canTakeDamage)
        {
            collision = true;
            this.GetComponent<lifeCount>().LoseLife();
        }
        if (col.gameObject.tag == "Coin")
        {
            pointsController.GetComponent<ScoreManager>().addPoint(5);
            coins++;
          
            if(coins >= 5)
            {
                this.GetComponent<lifeCount>().addLife();
                coins = 0;
            }
            col.gameObject.GetComponent<Note>().ParticleDestroy();
        }
    }
  
}
