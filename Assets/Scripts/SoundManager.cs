using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    public new AudioSource[] audio = new AudioSource[4];
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block1"))
        {
            audio[0].Play();
        }
        if (collision.gameObject.CompareTag("Block2"))
        {
            audio[1].Play();
        }
        if (collision.gameObject.CompareTag("Block3"))
        {
            audio[2].Play();
        }
        if (collision.gameObject.CompareTag("Block4"))
        {
            audio[3].Play();
        }
    }


}
