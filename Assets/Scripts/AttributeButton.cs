using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{

    public void SwitchButton(int points)
    {
        bool status = false;
        if(points > 0)
        {
            status = true;
        }

        gameObject.SetActive(status);
    }
}
