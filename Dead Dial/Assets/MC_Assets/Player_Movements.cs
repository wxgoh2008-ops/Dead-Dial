using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movements : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 MoveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = MoveInput * MoveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
