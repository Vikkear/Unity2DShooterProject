using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    Vector2 movementDirection;

    public float movementSpeed = 1f;


    private Vector3 vel;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        movementDirection = playerController.lastMovement;
    }
    private void Update()
    {
        Vector3 screenVector = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x < screenVector.x * -1 || transform.position.x > screenVector.x || transform.position.y > screenVector.y || transform.position.y < screenVector.y * -1)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
