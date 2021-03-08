using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

public class BulletTrailNoRigidbody : MonoBehaviour
{

    public float speed = 250;

    void Update()
    {
        // Move the trail
        transform.position = transform.position + transform.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<RagdollUtility>() != null)
        {
            collision.transform.GetComponent<Animator>().enabled = false;
            collision.transform.GetComponent<RagdollUtility>().applyIkOnRagdoll = false;
        }
    }
}
