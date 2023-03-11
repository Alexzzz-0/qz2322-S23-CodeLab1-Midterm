using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit A Dust!");
            GameManager.instance.dustNumLeft--;
            GameManager.instance.dustNumSolved++;
            GameManager.instance.RoomUIUpdate();
            Destroy(gameObject);
        }
    }
}
