using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public PlayerController controller;

    private float _translation = 0f;

    private void Update()
    {
        _translation = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        controller.Move(_translation * Time.deltaTime);
    }
}
