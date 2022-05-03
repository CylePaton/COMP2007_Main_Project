using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAnimation : MonoBehaviour
{
    public Animator animator;
    ParticleSystem ps;
    public AudioSource magicFX;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("MagicExplosion").GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public IEnumerator playParticle()
    {
        yield return new WaitForSeconds(0.3f);
        ps.Play();
        magicFX.Play();
    }
}
