using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{

    [SerializeField]
    private AudioClip buyWeapon;
    [SerializeField]
    private AudioClip dontCoins;
    [SerializeField]
    private GameObject textShopAccess;
    [SerializeField]
    private GameObject textNoAccessShop;
    [SerializeField]
    private GameObject textDontCoin;
    [SerializeField]
    private GameObject weapon;

    private UIManager uiManager;
    private bool shopActive = false;
    private Player player;

    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (shopActive)
        {
            if (player != null)
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
                {
                    if (player.hasCoin)
                    {
                        AudioSource.PlayClipAtPoint(buyWeapon, transform.position, 1f);
                        uiManager.BuyWeapon();
                        uiManager.CloseShop();
                        uiManager.SpendCoin();
                        player.hasCoin = false;
                        shopActive = false;
                    }
                    else
                    {
                        AudioSource.PlayClipAtPoint(dontCoins, transform.position, 1f);
                        uiManager.CloseShop();
                        shopActive = false;
                        textShopAccess.SetActive(false);
                        StartCoroutine(DontHaveCoin());
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!shopActive)
            {
                textShopAccess.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (weapon.activeInHierarchy)
                {
                    textNoAccessShop.SetActive(true);
                }
                else
                {
                    shopActive = true;
                    textShopAccess.SetActive(false);
                    player = other.GetComponent<Player>();
                    if (player != null)
                    {
                        if (uiManager != null)
                        {
                            uiManager.OpenShop();
                        }
                    }
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textShopAccess.SetActive(false);
            textNoAccessShop.SetActive(false);
            uiManager.CloseShop();
            shopActive = false;
        }
    }

    IEnumerator DontHaveCoin()
    {
        textDontCoin.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        textDontCoin.SetActive(false);
    }

}
