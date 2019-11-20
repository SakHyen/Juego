using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometer : MonoBehaviour
{

    public Text time;
    float cronometer = 300;

    // Start is called before the first frame update
    void Start()
    {
        time.text = "Hola";
    }

    // Update is called once per frame
    void Update()
    {
        cronometer -= Time.deltaTime;
        time.text = "" + Mathf.Floor(cronometer);
    }
}
