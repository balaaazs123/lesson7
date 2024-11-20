using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform background;
    
    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, player.transform.position.x, 0.05f),
            Mathf.Lerp(transform.position.y, player.transform.position.y, 0.05f),
            -1);

        background.transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, player.transform.position.x, 0.05f),
            Mathf.Lerp(transform.position.y, player.transform.position.y, 0.05f),
            0);
    }
}
