using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraControll : MonoBehaviour
{
    [SerializeField]private Transform playerTR;
    [SerializeField]private PlayerCTRL player;
    [Range(0,100)]public float cameraSpeed;
    public SpriteRenderer BackGround;
    private float mousePlayerXDis;
    private float mousePlayerYDis;
    
    private void Awake()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        BackGround.sprite = Resources.Load<Sprite>("BGSprite/"+SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        mousePlayerXDis = Mathf.Clamp( player.mousePos.x- playerTR.position.x, -3, 3);
        mousePlayerYDis = Mathf.Clamp(player.mousePos.y - playerTR.position.y, -1.4f, 3f);
        transform.position = Vector3.Lerp(transform.position,new Vector3(playerTR.position.x+mousePlayerXDis, playerTR.position.y+mousePlayerYDis,transform.position.z),cameraSpeed);
        
    }
}
