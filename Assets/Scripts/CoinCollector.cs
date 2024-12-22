using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCollector : MonoBehaviour
{
    private int coins =0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            cherriesText.text="cherries:" + coins;
        }


    }

}
