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

        new_pos.x = max(new_pos.x, -0.6102241f);
        new_pos.x = min(new_pos.x, 19.81245f);


        this.transform.position = new_pos;
    }

    float max(float a, float b) {
        return a > b ? a : b;
    }

    float min(float a, float b) {
        return a > b ? b : a;
    }
}
