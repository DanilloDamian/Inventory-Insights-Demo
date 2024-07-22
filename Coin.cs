using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinPickUp;
    [SerializeField]
    private GameObject textPickupCoin;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            textPickupCoin.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.HasCoin = true;
                    AudioSource.PlayClipAtPoint(coinPickUp, transform.position, 1f);
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }
                    textPickupCoin.SetActive(false);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textPickupCoin.SetActive(false);
        }
    }

}
