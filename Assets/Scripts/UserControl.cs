using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class UserControl : MonoBehaviour
{
    private Player character;
    private bool jump;
    private bool crouch;

    // Use this for initialization
    void Awake()
    {
        character = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!jump)
        {
            // Read the jump input in update so button presses arent missed
            jump = Input.GetButtonDown("Jump");
        }

    }

    void FixedUpdate()
    {
        //Read some input
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float move = Input.GetAxis("Horizontal");
        //Pass all paramaters into the character move
        character.Move(move, crouch, jump);
        jump = false;
    }
}
