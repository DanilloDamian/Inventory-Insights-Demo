using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Image coinImage;

    public void UpdateTextAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()
    {
        coinImage.gameObject.SetActive(true);
    }

}
