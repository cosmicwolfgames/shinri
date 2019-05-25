using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public PlayerController controller;

    private float translation = 0f;

    void Update()
    {
        translation = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        controller.Move(translation * Time.deltaTime);
    }
}
