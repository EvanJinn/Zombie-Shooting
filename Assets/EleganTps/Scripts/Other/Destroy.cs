using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

public class Destroy : MonoBehaviour
{
    public float destroyTime = 2;
    public float destroyTimeRandomize = 0;

    private float countToTime;

    // Use this for initialization
    void Awake()
    {
        destroyTime += Random.value * destroyTimeRandomize;
    }

    // Update is called once per frame
    void Update()
    {
        countToTime += Time.deltaTime;
        if (countToTime >= destroyTime)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<RagdollUtility>()!=null)
        {
            collision.transform.GetComponent<Animator>().enabled = false;
            collision.transform.GetComponent<RagdollUtility>().applyIkOnRagdoll = false;
        }
    }
}
