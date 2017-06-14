using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public GUIText coinText;
    public int coins;


    void Start()
    {
        coins = 0;
    }

    void Update()
    {
        UpdateCoins();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //If the player runs into the coin it will get destroyed and add another to the coin counter
        if (col.tag == "Item")
        {
            Destroy(col.gameObject);
            coins++;
        }
    }
    public void AddCoins (int newCoinValue)
    {
        coins += newCoinValue;
        UpdateCoins();
    }
    void UpdateCoins ()
    {
        coinText.text = "Coins: " + coins;
    }
}
