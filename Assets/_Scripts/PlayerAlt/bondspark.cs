using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondspark : MonoBehaviour {
    float CountDown;
    // Use this for initialization
    void Start()
    {
        CountDown = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0f)
        {
            Destroy(gameObject);
        }
    }
}