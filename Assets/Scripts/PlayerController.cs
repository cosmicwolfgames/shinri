using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [Range(0, .3f), SerializeField] 
   private float _movementSmoothing = .05f;

   private Rigidbody2D _rigidbody2D;
   private bool _facingRight = true;
   private Vector3 _velocity = Vector3.zero;

   private void Awake()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
   }

   public void Move(float move)
   {
      var rbVelocity = _rigidbody2D.velocity;
      Vector3 targetVelocity = new Vector2(move * 10f, rbVelocity.y);
 
      _rigidbody2D.velocity = Vector3.SmoothDamp(rbVelocity, targetVelocity, ref _velocity, _movementSmoothing);
      
      if (move > 0 && !_facingRight)
      {
         Flip();
      } else if (move < 0 && _facingRight)
      {
         Flip();
      }
   }
   
   private void Flip()
   {
      _facingRight = !_facingRight;

      var lTransform = transform;
      var theScale = lTransform.localScale;
      
      theScale.x *= -1;
      lTransform.localScale = theScale;
   }
   
}
