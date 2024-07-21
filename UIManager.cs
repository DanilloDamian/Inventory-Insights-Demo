using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Image coinImage;
    [SerializeField]
    private GameObject uiShop;
    [SerializeField]
    private GameObject weapon;

    public void UpdateTextAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()
    {
        coinImage.gameObject.SetActive(true);
    }

    public void SpendCoin()
    {
        coinImage.gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        uiShop.SetActive(true);
    }

    public void CloseShop()
    {
        uiShop.SetActive(false);
    }

    public void BuyWeapon()
    {
        weapon.SetActive(true);
    }

}
