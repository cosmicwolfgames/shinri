using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private void Update()
    {
        var translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        
        transform.Translate(translation, 0, 0);
    }
}
