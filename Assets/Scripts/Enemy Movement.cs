using UnityEngine;
using Unity.Mathematics;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxcollider;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxcollider = GetComponent<BoxCollider2D>();

    }

   
    void Update()
    {
     myRigidbody.linearVelocity = new Vector2(moveSpeed,0f);  
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }
    void FlipEnemyFacing()
    {
       
      transform.localScale = new Vector2(-(math.sign(myRigidbody.linearVelocity.x)),1f);
        
    }
}
