using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager I;

    void Awake()
    {
        I = this;
    }


    public Text timeTxt;
    public GameObject card;
    public GameObject endTxt;
    public GameObject failTxt;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioSource backgroundMusic;
    public AudioSource winSound;
    public AudioSource failSound;

    public bool isClick = true;
    public Text matchNumTxt;
    private int matchNum = 0;


    float time = 0.0f;
    int cardsLeft;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        backgroundMusic.Play();

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>(rtanName);
        }

        cardsLeft = GameObject.Find("cards").transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time > 30.0f)
        {
            backgroundMusic.Pause();
            failTxt.SetActive(true);
            Time.timeScale = 0.0f;
            time = 0;
            failSound.Play();
        }
    }

    public void isMatched()
    {
        isClick = false;
        matchNum += 1;
        matchNumTxt.text = ("      ¸ÅÄ¡È½¼ö " + matchNum.ToString() + "È¸");
        string firstCardImage 
            = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage 
            = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            //int cardsLeft = GameObject.Find("cards").transform.childCount;
            cardsLeft -= 2;
            Debug.Log(cardsLeft);
            if (cardsLeft == 0)
            {
                backgroundMusic.Pause();
                winSound.Play();
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;

    }

}
