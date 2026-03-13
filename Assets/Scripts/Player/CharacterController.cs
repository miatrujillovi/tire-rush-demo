using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    /*[Header("Run Settings")]
    [SerializeField] private float movementSpeed = 5f;
    [Space]*/
    [Header("Jump Settings")]
    [SerializeField, Tooltip("How high will the player jump based on it's rigibody physics.")] private float jumpForce = 11f;
    [SerializeField, Tooltip("Will contain the layer for the ground in order to help player detect the floor better.")] private LayerMask groundLayer;
    [SerializeField, Tooltip("Should contain a son inside the player with the position of it's feet.")] private Transform feetPosition;
    [SerializeField, Tooltip("Radious for how far away the player has to be from the ground in order to be considered Grounded.")] private float groundDistance = 0.25f;
    [SerializeField, Tooltip("Input Action connected with the Jump")] public InputActionReference jumpAction;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool doubleJumpUsed = false;
    [HideInInspector] public bool canDoubleJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Making the isGrounded work if the player's feet is in contact with the floor.
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);

        //Constant horizontal speed
        //rb.linearVelocity = new Vector2(movementSpeed, rb.linearVelocity.y);

        //Resetting double jump
        if (isGrounded)
        {
            doubleJumpUsed = false;
        }

        //Jumping Logic
        if (jumpAction.action.WasPressedThisFrame())
        {
            //First Jump
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                AudioManager.Instance.PlayJump();
                //Debug.Log("Jump!");
            }
            //Double Jump
            else if (canDoubleJump && !doubleJumpUsed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJumpUsed = true;
                AudioManager.Instance.PlayJump();
                //Debug.Log("Double Jump!");
            }
        }

    }
}
