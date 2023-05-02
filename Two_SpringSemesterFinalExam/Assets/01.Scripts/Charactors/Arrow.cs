using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask whatIsGround;
    public LayerMask monsterLayer;
    public int dmg;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = transform.up * 20;
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, monsterLayer);
        if (hit.collider)
        {
            hit.collider.GetComponent<GeneralAnimations>().takeDamage(dmg);
            Debug.Log("몬스터 감지");
            Destroy(this.gameObject);
        }
        else if (Physics2D.Raycast(transform.position,Vector2.up,0.5f,whatIsGround))
        {
            Destroy(this.gameObject);
        }
    }
}