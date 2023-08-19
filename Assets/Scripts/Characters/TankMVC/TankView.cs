using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public CharacterController characterController;
    private TankController _controller;
    private void Awake()
    {
        characterController = this.gameObject.GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        characterController.enabled = true;
        Debug.Log("character controller is "+characterController.enabled);
    }
    private void Start()
    {
        
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }

   
}
