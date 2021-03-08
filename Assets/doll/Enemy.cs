using UnityEngine;
using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    public Animator this_animator;
    public RagdollUtility this_ragdollUtility;
    // Start is called before the first frame update
    void Start()
    {
        this_animator = GetComponent<Animator>();
        this_ragdollUtility = GetComponent<RagdollUtility>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        //关闭动画 激活布娃娃系统
        if (collision.transform.GetComponent<Destroy>() != null) {
           
            this_animator.enabled = false;
            this_ragdollUtility.applyIkOnRagdoll = false;
            Debug.Log(collision.transform.name);
            this.GetComponent<AIMovement>().enabled = false;
        }
    }
}