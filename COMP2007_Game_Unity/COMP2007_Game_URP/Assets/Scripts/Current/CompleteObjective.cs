using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteObjective : MonoBehaviour
{
    // Variables to check objectives
    public int objNum = 0;
    public static bool obj0Comp = false;
    public static bool obj1Comp = false;
    public static bool obj2Comp = false;
    public static bool obj3Comp = false;
    public static bool obj4Comp = false;
    public static bool obj5Comp = false;
    public static bool obj6Comp = false;

    //Objective references
    public Image obj3;

    //Reference to tick image
    public Image tick;

    // Update is called once per frame
    void Update()
    {
        //Check if objective has been completed then set tick image to true
        if(objNum == 0 && obj0Comp)
        {
            tick.gameObject.SetActive(true);
        }
        if (objNum == 1 && obj1Comp)
        {
            tick.gameObject.SetActive(true);
        }
        if(objNum == 2 && obj2Comp)
        {
            tick.gameObject.SetActive(true);
        }
        if(obj2Comp == true)
        {
            obj3.gameObject.SetActive(true);
        }
        if(objNum == 3 && obj3Comp)
        {
            tick.gameObject.SetActive(true);
        }
    }
}
