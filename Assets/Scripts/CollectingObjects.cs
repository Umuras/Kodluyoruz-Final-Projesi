using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingObjects : MonoBehaviour
{
    public Text _scoreText;
    private int _counter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);

            _counter++;

            _scoreText.text = "Score: " + _counter;
        }
    }
}
