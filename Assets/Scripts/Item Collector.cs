using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int fishs = 0;


    [SerializeField] private Text fishsText;


    //There are multiple ways to find these different syntax and variables.
    //and the way to find them is really just by googling stuff - your friend in the web.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))//triggers the fish (Haha the puns i could make with this)
        {
            Destroy(collision.gameObject);//This destroys the fish upon collsion
            fishs++;
            fishsText.text = "Fishs: " + fishs;
        }
    }


}
