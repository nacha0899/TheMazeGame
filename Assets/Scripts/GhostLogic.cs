using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostLogic : MonoBehaviour
{
    //Positional vectors
    private Vector3 randomPosition;

    private GameObject playerTarget;
    private NavMeshAgent agent;

    //Animator Parameter to trigger animations
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        
        randomPosition = transform.position;
        playerTarget = GameObject.Find("Pac Racer X");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        _anim.SetTrigger("chase");

        // If Distance between player and the ghost is gerater than 0
        if (Vector3.Distance(transform.position, playerTarget.transform.position) > 0) 
        {
            // Will chase the player through the maze

            agent.SetDestination(playerTarget.transform.position);
           

        }
        
    }
}
