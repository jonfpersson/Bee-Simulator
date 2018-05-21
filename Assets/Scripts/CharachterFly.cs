using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterFly : MonoBehaviour {
    public Transform enemy;
    //public Transform target;
    //var rotationSpeed:int=2;
    //int rotationSpeed=2;

    public GameObject player;
    public float distance;
    public bool layer = false;
    //public Animator animator;
    protected Animator animator;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("FPSController");
        //animator=GetComponent(Animator);
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (layer == true)
        {
            transform.LookAt(player.transform);
            animator.SetBool("Run", layer);
        }
        distance = Vector3.Distance(player.transform.position, enemy.position);
        //Debug.Log("distance is " + distance);
        if (distance < 10)
        {
            layer = true;
            //transform.LookAt(player.transform);
            //animator.SetBool("Run", layer);
        }
    }
}
