using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    [Header("Movement")]

    public float moveSpeed;
    public float groundDrag;
    public float runSpeed;
    public float stamina;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public Image STimg;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    public Transform orientation;

    float horiznotalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("PlayerPoints")]
    public static float HP = 100;
    public Image HB;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
        horiznotalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
        //STimg.fillAmount = stamina / 100f;
    }

    private void PlayerMove()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horiznotalInput;

        if (grounded)
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 1)
            {
                stamina -= Time.deltaTime * 12;
                rb.AddForce(moveDirection.normalized * runSpeed * 10f, ForceMode.Force);

            }
            else if(verticalInput == 0 && horiznotalInput == 0)
            {
                if (stamina < 100.0001)
                {
                    stamina += Time.deltaTime * 20;
                }
            }
            else
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }

            if (verticalInput != 0 && horiznotalInput != 0)
            {

            }
        }

        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
    
    private void Awake()
    {

    }
}
