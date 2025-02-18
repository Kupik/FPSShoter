using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public ParticleSystem ExplosionBombDontHasTime;

    public BombDefusing bombDefusing;

    public void Start()
    {
        ExplosionBombDontHasTime = GetComponent<ParticleSystem>();
        // dezactivam

        // ExplosionBombDontHasTime.gameObject.SetActive(false);
    }

    public void Awake()
    {
        ExplosionBombDontHasTime.Stop();

        ExplosionBombDontHasTime = GetComponent<ParticleSystem>();

        if (ExplosionBombDontHasTime != null && bombDefusing.TimerForBomb <= 0)
        {
            StartCoroutine(DisanbleExplosion(ExplosionBombDontHasTime.main.duration));

        }
    }

    IEnumerator DisanbleExplosion(float TimeWait = 5)
    {
        yield return new WaitForSeconds(TimeWait);
        Debug.Log("Stop");
        ExplosionBombDontHasTime.Stop();
    }




}
