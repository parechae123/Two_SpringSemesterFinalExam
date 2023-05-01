using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCTRL : GeneralAnimations
{
    private Rigidbody2D rb;
    private float playerMoveAxis;
    private SpriteRenderer sr;
    public LayerMask whatIsGround;
    private CapsuleCollider2D cc;
    private byte jumpCount;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        
    }
    private void Start()
    {
        base.SettingStats(100, 20, 10, 5);
        base.LoadPlrStats();
        jumpCount = 0;
        StateUpdates(States.Idle);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2((playerMoveAxis*stat.moveSpeed), rb.velocity.y);
        if (!Keyboard.current.anyKey.wasPressedThisFrame&& !isInAttackAnim()&&playerMoveAxis ==0)
        {
            StateUpdates(States.Idle);
        }
    }

    public void SaveUpdatedPlayerStat()
    {
        base.SavePlrStats();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        playerMoveAxis = ctx.ReadValue<Vector2>().x;
        if (ctx.started)
        {
            if (playerMoveAxis < 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 1);
            }
            if (playerMoveAxis > 0)
            {
                transform.rotation = new Quaternion(0, 1, 0, 0);
            }
        }
        if (ctx.canceled)
        {
            StateUpdates(States.Idle);
        }
        if (ctx.performed)
        {
            StateUpdates(States.Run);
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started&&jumpCount<2)
        {
            rb.velocity+= Vector2.up * stat.jumpForce;
            jumpCount++;
            StateUpdates(States.Jump);
            if (jumpCount == 1)
            {
                StartCoroutine(jumpSencer());
            }
        }
    }

    private IEnumerator jumpSencer()
    {
        yield return new WaitUntil(() => rb.velocity.y < 0.5f);
        while (jumpCount > 0)
        {
            yield return new WaitForEndOfFrame();
            if (Physics2D.Raycast(transform.position, Vector2.down, cc.bounds.extents.y+0.01f, whatIsGround))
            {
                Debug.DrawRay(transform.position, Vector3.down * cc.bounds.extents.y, Color.red);
                jumpCount = 0;
            }
        }
    }
}
