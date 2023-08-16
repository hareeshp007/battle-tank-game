using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController characterController;

    public float speed=40f;
    float HorizontalMove = 0f;
    float VerticalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
       
    }
    private void MoveTank()
    {
        if (joystick.Horizontal >= .2f)
        {
            HorizontalMove = speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            HorizontalMove = -speed;
        }
        else if (joystick.Vertical >= .2f)
        {
            VerticalMove = speed;
        }
        else if (joystick.Vertical <= -.2f)
        {
            VerticalMove = -speed;
        }
        Debug.Log(HorizontalMove + " " + VerticalMove);
        Vector3 move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        characterController.Move(move * Time.deltaTime *speed);
    }
}
