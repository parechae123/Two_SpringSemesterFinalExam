using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform PlrTR;
    public CircleCollider2D Col;
    void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Col.bounds.extents.x, Vector2.zero,2, 128);
        if (hit)
        {
            Debug.Log("레이캐스트 작동");
            hit.collider.gameObject.GetComponent<PlayerAnimations>().takeDamage(40, transform.position);
            Debug.Log("아야");
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position,PlrTR.position,30*Time.deltaTime);
    }
}
