using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamLanes : MonoBehaviour
{
    public int lane;
    public float force;
    public GameObject arrow;
    public GameObject coin;
    private float cd = .3f;
    private float timeToSpawn = .3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (AudioPeer.freqBand[lane] > force && timeToSpawn <= 0)
        {
            if(Random.Range(0,100) >= 50)
            {
            Instantiate(arrow, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(coin, transform.position, Quaternion.identity);

            }
            timeToSpawn = cd;
        }
    }
}
