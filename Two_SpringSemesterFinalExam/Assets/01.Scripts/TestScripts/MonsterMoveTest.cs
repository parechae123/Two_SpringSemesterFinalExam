using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMoveTest : MonoBehaviour
{
    public Transform plrTR;
    public float speed;
    public Queue<BossProjectile> projectiles;
    // Start is called before the first frame update
    void Start()
    {
        plrTR = GameObject.Find("Player").transform;//�����ڵ忡�� �ִ� �׳� ���θ��
        Debug.Log(GameObject.FindObjectOfType<MonsterMoveTest>());//�̰ɷ� ��ũ��Ʈ ����ִ� ������Ʈ �Ǻ�
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, plrTR.position,speed*Time.deltaTime);
    }
}
