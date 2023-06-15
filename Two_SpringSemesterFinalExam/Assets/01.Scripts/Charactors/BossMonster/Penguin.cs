using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : BossBase
{
    public float degreesToPlr;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        MonsterDropItem = new HeadArmor();
        MonsterDropItem.SetItemValues();
        base.StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        degreesToPlr = (Mathf.Atan2(transform.position.x - plrTR.position.x, transform.position.y - plrTR.position.y)) * Mathf.Rad2Deg;
        if (plrTR.gameObject.activeSelf && atkDelay > 2)
        {
            if (Physics2D.OverlapCircle(transform.position - Vector3.down, 0.01f, 8))
            {
                Debug.Log("오버랩사이클 통과");
                if (Vector3.Distance(transform.position, plrTR.transform.position) < 15)
                {
                    Debug.Log("if문2단");
                    transform.position = Vector3.MoveTowards(transform.position, plrTR.position, (stat.moveSpeed * Time.deltaTime) * 7f);
                    transform.rotation = Quaternion.identity;
                }
            }
            else if (plrTR.position.y - transform.position.y >= 0.4f)
            {
                Debug.Log("if문1단");

                transform.position = Vector3.MoveTowards(transform.position, plrTR.position, (stat.moveSpeed * Time.deltaTime) * 8f);
                transform.rotation = Quaternion.AngleAxis(-degreesToPlr + 180, Vector3.forward);
                if (atkDelay > 5)
                {
                    atkDelay = 0;
                }
            }


        }
        if (plrTR.position.x- transform.position.x > 0)
        {
            sr.flipX = false;
        }
        else if (plrTR.position.x - transform.position.x < 0)
        {
            sr.flipX = true;
        }
        base.UpdateFunc();
    }
}
