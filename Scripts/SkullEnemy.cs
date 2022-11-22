using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SkullEnemy : MonoBehaviour
{
    [Header("Enemy patrol Status")]
    public float TimePatrol = 10;
    private WaitForSeconds time;
    public Transform[] PatrolPoints;
    private int index;

    [Header("Enemy Attack Status")]
    private playerLife playerLife;
    public int minDamage;
    public int maxDamage; 

    [Header("Enemy chase Status")]
    [SerializeField] private GameObject player;
    private bool takehere = false;
    [SerializeField] private float dist = 20;
    [SerializeField] private float disAttack;
    
    public bool attack = false;

    private NavMeshAgent agent;

    private Animator anim;

    void Awake(){
        agent = GetComponent<NavMeshAgent>();
        time = new WaitForSeconds(TimePatrol);
        anim = GetComponent<Animator>();
        index = Random.Range(0, PatrolPoints.Length);
        StartCoroutine(MovePatrol());

        disAttack = agent.stoppingDistance;

    }

    void Update(){
        TakeOnHere();
        AttackHere();
        anim.SetFloat("EnemyWalk", agent.velocity.sqrMagnitude, 0.6f, Time.deltaTime);
    }

    void TakeOnHere(){
    
    if(player != null && Vector3.Distance(transform.position, player.transform.position) < dist && !takehere){
         takehere = true;
    }else if(Vector3.Distance(transform.position, player.transform.position) > dist){
         takehere = false;
    }
    if(takehere){
       agent.SetDestination(player.transform.position);
    }
}

    void AttackHere(){
        if(player != null && Vector3.Distance(transform.position, player.transform.position) <= disAttack && takehere){
            
            attack = true;
        }else if(player != null && Vector3.Distance(transform.position, player.transform.position) > disAttack && takehere){
            attack = false;
            
        }

        if(attack){
            agent.speed = 0;anim.SetBool("EnemyAttack", true);
            agent.isStopped = true;
            
        }else{
            agent.speed = 2;anim.SetBool("EnemyAttack", false);
            agent.isStopped = false;
            
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dist);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, disAttack);
    }


    IEnumerator MovePatrol(){
        while(true){
            yield return time;
            Patroling();
        }
    }

    void Patroling (){
        index = index == PatrolPoints.Length - 1 ? 0 : index + 1;
        agent.SetDestination(PatrolPoints[index].position);
    }
}