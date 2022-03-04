using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    private float horizontal;
    private float vertical;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        GetInput();

        Move();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);
        transform.Translate(changeInPosition * Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }


}
