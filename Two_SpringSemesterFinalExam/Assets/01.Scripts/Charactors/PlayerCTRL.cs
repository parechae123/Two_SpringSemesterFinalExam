using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCTRL : GeneralAnimations
{
    private Rigidbody2D rb;
    private float playerMoveAxis;
    public LayerMask whatIsGround;
    private CapsuleCollider2D cc;
    private byte jumpCount;
    private Vector2 mousePos;
    private GameObject anchor;
    private float anchorLenght;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        
    }
    private void Start()
    {
        base.SettingStats(100, 20, 6, 5);
        base.LoadPlrStats();
        jumpCount = 0;
        StateUpdates(States.Idle);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2((playerMoveAxis*stat.moveSpeed), rb.velocity.y);
        if (!Keyboard.current.anyKey.wasPressedThisFrame&& !isInATKAnim()&&playerMoveAxis ==0)
        {
            StateUpdates(States.Idle);
        }
        if(playerMoveAxis != 0&& !isInATKAnim())
        {
            StateUpdates(States.Run);
        }
        if (anchor != null && anchorLenght != 0)
        {
            anchor.GetComponent<Anchor>().anchorSize((anchorLenght* 33)*Time.deltaTime);
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
    }
    public void OnWireSize(InputAction.CallbackContext ctx)
    {
        anchorLenght = ctx.ReadValue<Vector2>().y;
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started&&jumpCount<2)
        {
            rb.velocity+= Vector2.up * stat.jumpForce;
            jumpCount++;
            if(CharactorState != States.Attack)
            {
                StateUpdates(States.Jump);
            }
            if (jumpCount == 1)
            {
                StartCoroutine(jumpSencer());
            }
        }
    }
    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            StartCoroutine(ArrowFire());
        }
    }
    public void OnMousePosition(InputAction.CallbackContext ctx)
    {
        mousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    }
    public void OnAnchorFire(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            float angle = Mathf.Atan2(transform.position.x - mousePos.x, transform.position.y - mousePos.y) * Mathf.Rad2Deg;
            if (anchor != null)
            {
                Destroy(anchor.gameObject);
            }
            Debug.Log("¾ÞÄ¿¹ß»ç");
            anchor = Instantiate(Resources.Load<GameObject>("Prefabs/Anchor"), transform.position + (Vector3.up * 1.3f), Quaternion.identity);
            anchor.GetComponent<Anchor>().Player = gameObject;
            anchor.transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.forward);
        }
    }
    public void OnBreakAnchor(InputAction.CallbackContext ctx)
    {
        if (anchor != null)
        {
            Destroy(anchor);
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
    private IEnumerator ArrowFire()
    {
        if(!isInATKAnim())
        {
            StateUpdates(States.Attack);
            yield return new WaitForEndOfFrame();
            float angle = Mathf.Atan2(transform.position.x - mousePos.x, transform.position.y - mousePos.y) * Mathf.Rad2Deg;
            Debug.Log(angle);
            if (angle > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 1);
            }
            else
            {
                transform.rotation = new Quaternion(0, 1, 0, 0);
            }
            while (isInATKAnim())
            {
                yield return null;
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
                {
                    GameObject arrow = Instantiate(Resources.Load<GameObject>("Prefabs/arrow"), transform.position + (Vector3.up * 1.3f), Quaternion.identity);
                    arrow.transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.forward);
                    arrow.GetComponent<Arrow>().dmg = stat.atk;
                    break;
                }
            }
        }
    }
}
