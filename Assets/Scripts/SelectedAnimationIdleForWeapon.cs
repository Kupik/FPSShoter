
using UnityEngine;

public class SelectedAnimationIdleForWeapon : MonoBehaviour
{

    public Animator animator;
    public Item item; 

    public void Start()
    {
        animator.Play(item.idle_animation);
    }

    public void WPSelect()
    {
        // ani
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(item.idle_animation))
        {
            
            Debug.Log("Character is idle");
        }
        else
        {
            // daca nu e strea idel voi folosi alt ceva
        }
    }


}

