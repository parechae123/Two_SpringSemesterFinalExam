using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMoveTest : MonoBehaviour
{
    public Transform plrTR;
    public float speed;
    public Queue<BossProjectile> projectiles;
    public Collider2D monsterCol;
    public float degreesToPlr;
    // Start is called before the first frame update
    void Start()
    {
        monsterCol = GetComponent<Collider2D>();
        plrTR = GameObject.Find("Player").transform;//�����ڵ忡�� �ִ� �׳� ���θ��
        Debug.Log(GameObject.FindObjectOfType<MonsterMoveTest>());//�̰ɷ� ��ũ��Ʈ ����ִ� ������Ʈ �Ǻ�
        
    }

    // Update is called once per frame
    void Update()
    {
        degreesToPlr = (Mathf.Atan2( transform.position.x- plrTR.position.x,  transform.position.y- plrTR.position.y )) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-degreesToPlr, Vector3.forward);
        /*        if (Vector2.Distance(transform.position,plrTR.transform.position)< 7)
                {
                    transform.position = Vector3.MoveTowards(transform.position, plrTR.position, speed * Time.deltaTime); 
                }*/
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, monsterCol.bounds.extents.x, Vector2.zero,2,128);
        if (hit)
        {
            Debug.Log("����ĳ��Ʈ �۵�");
        }
    }
}
