using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int collisions = 0;

    int pointsBlock1 = 5;
    int pointsBlock2 = 10;
    int pointsBlock3 = 7;
    int pointsBlock4 = 3;

    int points;

    AudioSource audioSource;

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

        Debug.Log($"Collision:{collisions} Points:{points}");
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


        Debug.Log($"Collision:{collisions} points:{points}");

    }

    //void Update()
    //{
    //    //Check to see if you just set the toggle to positive
    //    if (play == true && toggleSound == true)
    //    {
    //        //Play the audio you attach to the AudioSource component
    //        sound_sphere = GetComponent<AudioSource>();
    //        sound_sphere.Play();
    //        //Ensure audio doesn’t play more than once
    //        toggleSound = false;
    //    }
    //    //Check if you just set the toggle to false
    //    if (play == false && toggleSound == true)
    //    {
    //        //Stop the audio
    //        sound_sphere.Stop();
    //        //Ensure audio doesn’t play more than once
    //        toggleSound = false;
    //    }
    //}
}
