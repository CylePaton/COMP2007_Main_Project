using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHint : MonoBehaviour
{
    bool showHint = false;
    public Image hint;

    private void OnTriggerEnter(Collider other)
    {
        showHint = true;
    }

    private void OnTriggerExit(Collider other)
    {
        showHint = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showHint)
        {
            hint.gameObject.SetActive(true);
        }
        else
        {
            hint.gameObject.SetActive(false);
        }
    }
}
