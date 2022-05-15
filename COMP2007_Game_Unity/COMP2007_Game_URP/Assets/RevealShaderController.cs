using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealShaderController : MonoBehaviour
{
    //References
    public TreeShrine treeShrine;

    //Counter for clip threshold
    float counter = 0.6f;

    //Materal on the object
    public Material leafMaterial;
    public Material treeMaterial;

    // Start is called before the first frame update
    void Start()
    {
        treeMaterial.SetFloat("_Clip_Threshold", counter);
        leafMaterial.SetFloat("_Clip_Threshold", counter);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Counts down, which in turn will change the clip threshold each update
        

        //When the tree shrine is active, modify clip theshold property off shader to reveal stree
        if (treeShrine.treeShrineActive == true)
        {
            counter = counter - 0.002f;
            treeMaterial.SetFloat("_Clip_Threshold", counter);
            leafMaterial.SetFloat("_Clip_Threshold", counter);
        }
    }
}
