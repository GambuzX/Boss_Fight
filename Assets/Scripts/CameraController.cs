using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<knight_movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_pos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        this.transform.position = new_pos;
    }
}
