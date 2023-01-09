using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= -5)
        { 
            transform.position = Vector3.Slerp(new Vector3 (transform.position.x, transform.position.y, -10),
                                                      new Vector3(player.position.x, player.position.y, -10), 3 * Time.deltaTime);
        }
    }
}
