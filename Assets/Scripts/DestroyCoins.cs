using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
    public GameObject coins;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroys the falling coin 2 seconds after it spawns
        Destroy(gameObject, 2f);
    }
}
