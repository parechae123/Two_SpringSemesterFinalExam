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
        plrTR = GameObject.Find("Player").transform;//원래코드에선 애는 그냥 냅두면됨
        Debug.Log(GameObject.FindObjectOfType<MonsterMoveTest>());//이걸로 스크립트 들어있는 오브젝트 판별
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, plrTR.position,speed*Time.deltaTime);
    }
}
