using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int collisions = 0;

    int pointsBlock1 = 5; 
    int pointsBlock2 = 10;
    int pointsBlock3 = 7;
    int pointsBlock4 = 3;

    int points;
    private void OnCollisionEnter(Collision collision)
    {
        collisions++;

        if (collision.gameObject.CompareTag("Block1"))
        {
            points += pointsBlock1;
        }
        else if (collision.gameObject.CompareTag("Block2"))
{
            points += pointsBlock2;
        }
        else if (collision.gameObject.CompareTag("Block3"))
        {
            points += pointsBlock3;
        }
        else if (collision.gameObject.CompareTag("Block4"))
        {
            points += pointsBlock4;
        }
        
        Debug.Log($"Collisions:{collisions} points:{points}");
    }

    private void OnCollisionExit(Collision collision)
    {
        collisions--;

        if (collision.gameObject.CompareTag("Block1"))
        {
            points -= pointsBlock1;
        }
        else if (collision.gameObject.CompareTag("Block2"))
        {
            points -= pointsBlock2;
        }
        else if (collision.gameObject.CompareTag("Block3"))
        {
            points -= pointsBlock3;
        }
        else if (collision.gameObject.CompareTag("Block4"))
        {
            points -= pointsBlock4;
        }

        Debug.Log($"Collisions:{collisions} points: {points}");
    }
}
