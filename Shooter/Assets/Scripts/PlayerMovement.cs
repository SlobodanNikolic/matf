using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Camera cam;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    [SerializeField] Weapon weapon;

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
        RotateCharacter();

        if(Input.GetMouseButton(0))
        {
            if(weapon != null)
            {
                weapon.Shoot();
            }
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
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
        Vector3 goToPositon = transform.position + changeInPosition * speed * Time.deltaTime;
        rigidbody.MovePosition(goToPositon);
        // transform.Translate(changeInPosition * Time.deltaTime * speed);
    }

    private void RotateCharacter()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }


}
