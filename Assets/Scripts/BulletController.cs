using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    Vector2 movementDirection;

    public float movementSpeed = 1f;
    private Camera cam;
    private int screenWidth = 8;
    private int screenHeight = 4;
    private RectTransform rectTransform;

    private Vector3 vel;
    private float width;
    private float height;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        movementDirection = playerController.lastMovement;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rectTransform = GetComponent<RectTransform>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Update()
    {
        Vector3 screenVector = cam.transform.position;


        if (transform.position.x < screenVector.x - screenWidth - width * 2 || transform.position.x > screenVector.x + screenWidth + width * 2 || transform.position.y > screenVector.y + screenHeight + height * 2 || transform.position.y < screenVector.y - screenHeight - height * 2)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
