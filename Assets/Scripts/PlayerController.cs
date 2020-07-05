using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public GameObject firePoint;
    public float movementSpeed = 1.5f;
    public Vector2 movement;

    public Vector2 lastMovement;

    [SerializeField] private StaminaBar staminaBar;
    [SerializeField] private StaminaBar healthBar;

    private float savedMovement;
    private float stamina = 100;
    private int health = 100;
    private bool isRunning = false;

    public GameObject bullet;

    private void Start()
    {
        savedMovement = movementSpeed;
        lastMovement = new Vector2(1, 0);
        movement = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey("left shift") && stamina > 10)
        {
            movementSpeed = 3.5f;
            isRunning = true;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyUp("left shift"))
        {
            movementSpeed = savedMovement;
            isRunning = false;
        }

        if (stamina <= 0)
        {
            isRunning = false;
            movementSpeed = savedMovement;
        }

        // Shoot mechanic
        if (Input.GetMouseButtonDown(0))
        {
            double angle = Math.Atan2(firePoint.transform.position.y - transform.position.y, firePoint.transform.position.x - transform.position.x) * (180 / Math.PI);
            Instantiate(bullet, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0), Quaternion.Euler(0, 0, (float)angle));
        }

        staminaBar.setSize(stamina * 0.01f);
        healthBar.setSize(health * 0.01f);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);

        if (movement != new Vector2(0, 0))
        {
            firePoint.transform.position = transform.position + new Vector3(movement.x, movement.y, 0);
            lastMovement = movement;
        }


        if (isRunning)
        {
            stamina -= 0.5f;
        }
        else if (!isRunning && stamina < 100)
        {
            stamina += 0.25f;
        }
    }

    private void takeDamage(int damageDealt)
    {
        health -= damageDealt;
        if (health <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        Debug.Log("Ded");
    }
}
