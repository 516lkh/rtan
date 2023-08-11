using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeTxt : MonoBehaviour
{
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
        GetComponent<RectTransform>().position
                = new Vector3(x + Random.Range(-0.1f* gameManager.I.time, 0.1f* gameManager.I.time), y + Random.Range(-0.1f* gameManager.I.time, 0.1f* gameManager.I.time), 0);
        
    }
}
