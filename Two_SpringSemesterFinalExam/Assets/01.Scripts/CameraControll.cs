using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [Range(0,100)]public float cameraSpeed;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z)-(new Vector3(-1.3f,-1,0)*3),cameraSpeed);
    }
}
