using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTransform = null;
    public GoalScript goalTransform = null;
    public EnemyCombat enemyCombat;
    public Animator animator;
    public Transform ballEffectorGO;
    private Vector3 ballEffectorOriginalPosition = Vector3.zero;
    Vector3 localDirection;
    public bool IsWalking = false;
    [SerializeField]
    private float animationSmoothFactor = 0.1f;

    private void Start()
    {
        goalTransform = FindObjectOfType<GoalScript>();
        ballEffectorOriginalPosition = ballEffectorGO.transform.localPosition;
    }

    private void Update()
    {
        //When player is at range
        if (IsWalking && playerTransform != null)//enemy within collider
        {
            MoveAgent(playerTransform);
            if (enemyCombat.IsAtDistance) //enemy at distance of sword
            {
                animator.SetTrigger("attack");
                ballEffectorGO.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.7f, playerTransform.position.z);
                //
            }
            else
            {
                ballEffectorGO.localPosition = ballEffectorOriginalPosition;
            }

        }
        else //we lost the player but we have a GOALScript
        {
            //StopAgentMovement();
            MoveAgent(goalTransform.transform);
            //Detect enemy in proximity and see if he is attacking
            //if he is attacking, stop!
            //if no one is attacking, attack!
        }
        //we lost the player and we dont have a GOalScript
        //...
    }

    public void MoveAgent(Transform player)
    {
        localDirection = transform.InverseTransformDirection(agent.velocity);
        agent.SetDestination(player.position);

        animator.SetFloat("MoveX", localDirection.x);
        animator.SetFloat("MoveZ", localDirection.z);
    }

    public void StopAgentMovement()
    {
        agent.velocity = Vector3.zero;
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveZ", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLayer has entered!");
            IsWalking = true;
            //follow the player
            playerTransform = other.transform;
            //attack the player
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLayer exit the collider!");
            IsWalking = false;
            playerTransform = null;
            //return to patrol, original position
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 6.5f);
    }

}
