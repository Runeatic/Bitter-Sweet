using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finale : MonoBehaviour
{
    private MenuManager menuManager;

        private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            menuManager.showFinale();
        }
    }
}
