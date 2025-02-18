using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    // folllow player
    [SerializeField] private GameObject _player;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => _player; }
    public Path path;
    [Header("Sight Values")]
    public float sightDistance = 80f;
    public float fieldOfView = 185f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel; // gun
    [Range(0.1f, 10f)] // viteza fire rate maxima
    public float fireRate; 
    [SerializeField]
    private string currentState;
    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(_player != null)
        {
            // daca jucatorul eeste destul de aproape ca sal poata vedea enemy
            if(Vector3.Distance(transform.position, _player.transform.position) < sightDistance)
            {

                //calculam angle(coltul de vedere) catre playerul nostru
                Vector3 targetDirection = _player.transform.position - transform.position - (Vector3.up * eyeHeight); //angle(coltul de vedere) intre player si enemy           
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                // verificam daca playerul intra in zona de vedere a enemy(lor)
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    // desenam un straluci de la player pinala enemy pentrua vedea daca nui blocheaza nimic 
                    // Nui ese nimic in fata sa blochee detectarea ce poate provoca baguri
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        if(hitInfo.transform.gameObject == _player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
              
                }
            }
        }
                return false;
    }


    
}
