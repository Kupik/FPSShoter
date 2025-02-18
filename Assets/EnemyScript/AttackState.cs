using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState 
{

    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;

    public float damageAmount = 10f; // Cantitatea de damage aplicată
    public float raycastLength = 100f; // Lungimea raycast-ului




    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {                           
        if(enemy.CanSeePlayer()) // poate vedea player
        {
            // Blocați cronometrul de pierdere al jucătorului și creșteți
            // cronometrele de mișcare și aruncare
            losePlayerTimer = 0;
            moveTimer  += Time.deltaTime;
            shootTimer += Time.deltaTime;
            Vector3 looksPositionPlayer = enemy.Player.transform.position; // urmarirea playaer pe axa Y
            looksPositionPlayer.y = enemy.transform.position.y; // pastreaza enemy pe axa Y pentru a nu se inclina sau rostogoli
            enemy.transform.LookAt(looksPositionPlayer); // axa Y
            // if shoot time > fireRate
            if(shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            // MISCAREA enemy intrun moment random dintre 3 si 7s
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                // Change to search state
                //acma pun patrol
                stateMachine.ChangeState(new PatrollState());
            }
        }
    }

    public void Shoot()
    {
        // SALVAM REFERINTA LA ARM
        Transform gunM4A1 = enemy.gunBarrel.transform;
        // Cream un bullet nou
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefab/Bullet") as GameObject, gunM4A1.position, enemy.transform.rotation);
        // directia catre player
        Vector3 shootDirection = (enemy.Player.transform.position - gunM4A1.transform.position).normalized;
        // forta la bullet
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 60;
        Debug.Log("pOPAL");
shootTimer = 0;

    }   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
