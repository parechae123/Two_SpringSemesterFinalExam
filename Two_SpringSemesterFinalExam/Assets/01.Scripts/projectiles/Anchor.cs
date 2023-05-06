using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    Rigidbody2D rb;
    SpringJoint2D joint;
    LineRenderer LR;
    public LayerMask whatIsGround;
    public LayerMask monsterLayer;
    public GameObject Player;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();
        LR = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, monsterLayer);
        if (hit.collider|| Vector3.Distance(Player.transform.position,transform.position) > 13 )
        {
            Destroy(gameObject);
        }
        if (Physics2D.Raycast(transform.position, Vector2.up, 0.5f, whatIsGround))
        {
            rb.velocity = Vector2.zero;
            if (joint.connectedBody == null)
            {
                LR.SetPosition(0, transform.position);
                joint.connectedBody = Player.GetComponent<Rigidbody2D>();
            }
            LR.SetPosition(1, Player.transform.position);
        }
        else
        {
            rb.velocity = transform.up * 20;
        }
    }
    public void anchorSize(float sizeControl)
    {
        if(joint.distance<= 10)
        {
            joint.distance += sizeControl;
            /*joint.frequency -= sizeControl/3;*/
        }
        else
        {
            joint.distance = 10;
        }
    }
}
