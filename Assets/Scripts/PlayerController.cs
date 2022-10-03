
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
        
        if(collision)
        {
           
        }
     }
        
    

    private void Move(Vector2 direction){
        if(CanMove(direction))
        {
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
        if (col.gameObject.tag == "Note")
        {
            collision = true;
        }
    }
  
}
