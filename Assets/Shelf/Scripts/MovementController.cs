using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public GameObject cameraGameObject;

    private float xDirection;
    private float yDirection;
    public float speed;
    public float moveSpeed;

    void Start()
    {

    }

    void Update()
    {
        //Read Mouse Input Values
        xDirection = Input.GetAxis("Mouse X");
        yDirection = -Input.GetAxis("Mouse Y");

        //Rotate the player and Camera
        this.transform.Rotate(0, xDirection * speed, 0);

        cameraGameObject.transform.Rotate(yDirection * speed, 0, 0);

        //Locking the Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        var Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(Move * moveSpeed * Time.deltaTime, Space.World);
    }

   
}