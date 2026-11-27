using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movements : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 MoveInput;
    private Animator animator;
    private float LastFace_X = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = MoveInput * MoveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);

        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInput_X", LastFace_X);
            animator.SetFloat("LastInput_Y", 0f);

        }

        MoveInput = context.ReadValue<Vector2>();

        if (MoveInput.x != 0) LastFace_X = Mathf.Sign(MoveInput.x);

        animator.SetFloat("Input_X", LastFace_X);
        animator.SetFloat("Input_Y", 0f);
    }
}
