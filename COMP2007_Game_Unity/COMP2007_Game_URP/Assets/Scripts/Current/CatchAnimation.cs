using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAnimation : MonoBehaviour
{
    //References
    public Animator animator;
    public AudioSource magicFX;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        //Getting particle system
        ps = GameObject.Find("MagicExplosion").GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses the left mouse button then start a coroutine (so the effects activate at the peak of the animation)
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("UsingStaff", true);
            StartCoroutine(playParticle());
        }
        else
        {
            animator.SetBool("UsingStaff", false);
        }
    }

    //Particle and sound effects
    public IEnumerator playParticle()
    {
        yield return new WaitForSeconds(0.3f);
        ps.Play();
        magicFX.Play();
    }
}
