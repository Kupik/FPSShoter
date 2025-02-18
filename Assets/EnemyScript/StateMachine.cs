using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public Animator animator;

    public void Initialise()
    {
        //setup default
        ChangeState(new PatrollState());
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if(activeState != null)
        {
            activeState.Perform();
        }
        
    }

    public void ChangeState(BaseState newState) {

        // facem un swich la character dintro stare in alta
        if(activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;


        

        if(activeState != null )
        {
           
            // o noua stare
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }

        
            
            
             
    }

}
