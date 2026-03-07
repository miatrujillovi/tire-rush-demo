using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField, Tooltip("How high will the player jump based on it's rigibody physics.")] private float jumpForce = 10f;
    [SerializeField, Tooltip("Will contain the layer for the ground in order to help player detect the floor better.")] private LayerMask groundLayer;
    [SerializeField, Tooltip("Should contain a son inside the player with the position of it's feet.")] private Transform feetPosition;
    [SerializeField, Tooltip("Radious for how far away the player has to be from the ground in order to be considered Grounded.")] private float groundDistance = 0.25f;
    [SerializeField, Tooltip("Input Action connected with the Jump")] private InputActionReference jumpAction;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Making the isGrounded work if the player's feet is in contact with the floor.
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);

        //Making the player Jump
        if (isGrounded && jumpAction.action.WasPressedThisFrame())
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce;
            Debug.Log("Jump!");
        }
    }
}
