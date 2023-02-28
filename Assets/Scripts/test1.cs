using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.level = 1;
    }
}
