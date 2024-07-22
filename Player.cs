using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.7f;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private GameObject hitMarketPrefab;
    [SerializeField]
    private AudioSource weaponAudio;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject textNeedReload;
    [SerializeField]
    private GameObject textReloading;
    [SerializeField]
    private int currentAmmo;

    private int maxAmmo = 50;
    private float gravity = 9.81f;
    private CharacterController characterController;
    private UIManager uiManager;
    private bool isReLoading = false;
    public bool HasCoin = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0 && !isReLoading && weapon.activeInHierarchy)
        {
            Shoot();
        }
        else
        {
            muzzleFlash.SetActive(false);
            weaponAudio.Stop();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReLoading && weapon.activeInHierarchy)
        {
            isReLoading = true;
            StartCoroutine(Reload());
        }
        if (currentAmmo <= 0 && !isReLoading && weapon.activeInHierarchy)
        {
            textNeedReload.SetActive(true);
        }
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Shoot()
    {
        muzzleFlash.SetActive(true);
        currentAmmo--;
        uiManager.UpdateTextAmmo(currentAmmo);
        if (!weaponAudio.isPlaying)
        {
            weaponAudio.Play();

        }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            GameObject hitMarket = Instantiate(hitMarketPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitMarket, 1f);

            Destructable crate = hitInfo.transform.GetComponent<Destructable>();
            if (crate)
            {
                crate.DestroyBox();
            }
        }
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);
        characterController.Move(velocity * Time.deltaTime);
    }

    IEnumerator Reload()
    {
        textNeedReload.SetActive(false);

        for (int i = 0; i < 6; i++)
        {
            textReloading.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            textReloading.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
        currentAmmo = maxAmmo;
        uiManager.UpdateTextAmmo(currentAmmo);
        isReLoading = false;
    }

}
