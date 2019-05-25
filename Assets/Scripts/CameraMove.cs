using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 oldPosition;
    private float z;
    public float lerp;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
        oldPosition = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(pos, oldPosition, lerp * Time.deltaTime);
        oldPosition = pos;
    }
}
