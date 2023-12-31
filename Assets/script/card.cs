using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    public AudioSource audioSource;
    public SpriteRenderer backColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCard()
    {
        if (gameManager.I.isClick == true)
        {
            audioSource.Play();
            anim.SetBool("isOpen", true);
            anim.SetBool("isFlip", true);
            Invoke("closeflip", 0.15f);

            transform.Find("front").gameObject.SetActive(true);
            transform.Find("back").gameObject.SetActive(false);

            backColor.color = new Color(168 / 255f, 168 / 255f, 168 / 255f, 255);

            if (gameManager.I.firstCard == null)
            {
                gameManager.I.firstCard = gameObject;
            }
            else
            {
                gameManager.I.secondCard = gameObject;
                gameManager.I.isMatched();
            }

        }

    }


    public void destroyCard()
    {
        gameManager.I.isClick = true;
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }




    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isFlip", true);
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        Invoke("closeflip", 0.15f);
        gameManager.I.isClick = true;
    }


    void closeflip()
    {
        anim.SetBool("isFlip", false);
    }



}
