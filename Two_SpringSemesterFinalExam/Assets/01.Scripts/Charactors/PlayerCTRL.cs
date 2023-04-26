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
        base.SettingStats();
        base.LoadPlrStats();
        jumpCount = 0;
    }
    private void Update()
    {
        rb.velocity = new Vector2((playerMoveAxis*stat.moveSpeed)*Time.deltaTime, rb.velocity.y);
    }

    public void SaveUpdatedPlayerStat()
    {
        base.SavePlrStats();
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
        if (ctx.started&&jumpCount<2)
        {
            rb.velocity+= Vector2.up * stat.jumpForce;
            jumpCount++;
            Debug.Log("jumped");
            if(jumpCount == 1)
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
