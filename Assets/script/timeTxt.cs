using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeTxt : MonoBehaviour
{
    float time = 0.0f;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if(time < 10f)
        {

        }
        else if (time < 20f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-1, 1), y + Random.Range(-1, 1), 0);
        }
        else if (time < 30f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-3, 3), y + Random.Range(-3, 3), 0);
        }
        else if (time < 40f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-5, 5), y + Random.Range(-5, 5), 0);
        }
        else if (time < 50f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-10, 10), y + Random.Range(-10, 10), 0);
        }
    }
}
