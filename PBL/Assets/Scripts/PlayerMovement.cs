using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento lateral
    public float jumpForce = 10f; // Fuerza de salto
    public Transform groundCheck; // Transform del objeto que verifica si estamos en el suelo
    public LayerMask groundMask; // Capa en la que se considera que estamos en el suelo

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si estamos en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Movimiento lateral
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}


