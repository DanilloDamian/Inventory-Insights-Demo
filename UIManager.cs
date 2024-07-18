using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;

    public void UpdateTextAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }

}
