using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCTRL : MonoBehaviour
{
    private Rigidbody2D rb;
    private float playerMoveAxis;
    private SpriteRenderer sr;
    [SerializeField] public PlayerStats playerStats;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        rb.velocity = new Vector2((playerMoveAxis*playerStats.moveSpeed)*Time.deltaTime, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        playerMoveAxis = ctx.ReadValue<Vector2>().x;
        if (playerMoveAxis < 0)
        {
            sr.flipX = true;
        }
        if (playerMoveAxis > 0)
        {
            sr.flipX = false;
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            rb.velocity+= Vector2.up * playerStats.jumpForce;
        }
    }
    [System.Serializable] public struct PlayerStats
    {
        public float moveSpeed;
        public float playerHP;
        public float jumpForce;
    }
}
