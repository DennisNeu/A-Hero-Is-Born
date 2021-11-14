﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public float bulletSpeed = 100f;


    private float vInput;
    private float hInput;

    private Rigidbody rb;
    private CapsuleCollider col;

    private GameBehaviour gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*
       transform.Translate(Vector3.forward * vInput * Time.deltaTime);
       transform.Rotate(Vector3.up * hInput * Time.deltaTime);
       */

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.deltaTime);
        rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

        if (Input.GetMouseButtonDown(0)) {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }

    private bool IsGrounded() {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name == "Enemy") {
            gameManager.HP -= 1;
        }
    }
}
