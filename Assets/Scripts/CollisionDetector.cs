using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int collisions = 0;
    int points;
    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        points += collision.gameObject.GetComponent<Block>().Points;
        Debug.Log($"Collisions:{collisions} points:{points}");
    }

    private void OnCollisionExit(Collision collision)
    {
        collisions--;
        points -= collision.gameObject.GetComponent<Block>().Points;
        Debug.Log($"Collisions:{collisions} points: {points}");
    }
}
