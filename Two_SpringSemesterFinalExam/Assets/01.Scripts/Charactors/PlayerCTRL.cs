using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCTRL : GeneralAnimations
{
    private float playerMoveAxis;
    public LayerMask whatIsGround;
    private CapsuleCollider2D cc;
    private byte jumpCount;
    public Vector2 mousePos;
    private GameObject anchor;
    private Anchor anchorCOMP;
    private float anchorLenght;
    #region ������
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        anchor = Instantiate(Resources.Load<GameObject>("Prefabs/Anchor"));
        anchorCOMP = anchor.GetComponent<Anchor>();
        anchorCOMP.Player = gameObject;
        base.SettingStats(100, 20, 6, 5);
        base.SavePlrStats();
        base.LoadPlrStats();
        jumpCount = 0;
        StateUpdates(States.Idle);
    }
    #endregion
    #region ������Ʈ
    private void FixedUpdate()
    {
        if(CharactorState != States.Damaged)
        {
            rb.velocity = new Vector2((playerMoveAxis * stat.moveSpeed), rb.velocity.y);
            if (!Keyboard.current.anyKey.wasPressedThisFrame && !isInATKAnim() && playerMoveAxis == 0)
            {
                StateUpdates(States.Idle);
            }
            if (playerMoveAxis != 0 && !isInATKAnim())
            {
                StateUpdates(States.Run);
            }
            if (anchor.activeSelf && anchorLenght != 0)
            {
                anchorCOMP.anchorSize((anchorLenght * 33) * Time.deltaTime);
            }
        }
    }
    #endregion
    #region ���۹�
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (CharactorState != States.Damaged&& CharactorState != States.Die)
        {
            playerMoveAxis = ctx.ReadValue<Vector2>().x;
            if (ctx.started)
            {
                if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��1: �̵�����")
                {
                    UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                    UIManager.Instance().isQuestDone(true);
                }
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
        else if (CharactorState == States.Die)
        {
            StateUpdates(States.Die);
        }
    }
    public void OnWireSize(InputAction.CallbackContext ctx)
    {
        anchorLenght = ctx.ReadValue<Vector2>().y;
        if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��6: ���̾� ����")
        {
            UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
            UIManager.Instance().isQuestDone(true);
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started&&jumpCount<2)
        {
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��2: ����")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }

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
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��3: ����")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
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
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��5: ���̾� ��ġ")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
            float angle = Mathf.Atan2(transform.position.x - mousePos.x, transform.position.y - mousePos.y) * Mathf.Rad2Deg;
            if (anchor.activeSelf)
            {
                anchor.SetActive(false);
            }
            anchor.SetActive(true);
            anchor.transform.position = transform.position + (Vector3.up * 1.3f);
            anchor.transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.forward);
            anchorCOMP.Player = gameObject;
        }
    }
    public void OnBreakAnchor(InputAction.CallbackContext ctx)
    {
        if (anchor.activeSelf)
        {
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��7: ���̾� ����")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
            anchor.SetActive(false);
        }
    }
    #endregion
    #region �ڷ�ƾ
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
        if (CharactorState != States.Damaged || CharactorState != States.Die)
        {
            if (!isInATKAnim())
            {
                StateUpdates(States.Attack);
                yield return new WaitForEndOfFrame();
                float angle = Mathf.Atan2(transform.position.x - mousePos.x, transform.position.y - mousePos.y) * Mathf.Rad2Deg;
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
                        if (GameManager.GMinstance().nonActivateArrows.Count == 0)
                        {
                            GameObject arrow = Instantiate(Resources.Load<GameObject>("Prefabs/arrow"), transform.position + (Vector3.up * 1.3f), Quaternion.AngleAxis(-angle + 180, Vector3.forward));
                            Debug.Log("ȭ�� ����");
                            arrow.GetComponent<Arrow>().dmg = stat.atk;
                        }
                        else
                        {
                            GameObject arrow = GameManager.GMinstance().nonActivateArrows.Dequeue();
                            arrow.transform.position = transform.position + (Vector3.up * 1.5f);
                            arrow.transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.forward);
                            arrow.SetActive(true);
                            Debug.Log("���� ȭ��" + GameManager.GMinstance().nonActivateArrows.Count);
                            arrow.GetComponent<Arrow>().dmg = stat.atk;
                        }
                        break;
                    }
                }
            }
        }

    }
    #endregion
}
