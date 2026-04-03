using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointFoRCoinPickup = 100;
    bool wasCollected = false;
   
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            Destroy(gameObject);
            gameObject.SetActive(false);
            FindFirstObjectByType<GameSessions>().AddtoScore(pointFoRCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX,transform.position);
           

        }
    }

    
        
    
}
