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
                = new Vector3(x + Random.Range(-2, 2), y + Random.Range(-2, 2), 0);
        }
        else if (time < 25f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-5, 5), y + Random.Range(-5, 5), 0);
        }
        else if (time < 30f)
        {
            GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-15, 15), y + Random.Range(-15, 15), 0);
        }
    }
}
