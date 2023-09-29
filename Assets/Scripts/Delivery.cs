using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColor;
    [SerializeField] Color32 hasPackageColor;

    [SerializeField] TMP_Text deliveredPackagesText;
    [SerializeField] float destroyTime = 0.5f;
    GameObject package;
    bool isPicked;
    int deliveredPackages = 0;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        deliveredPackagesText.text = "Delivered Packages : 0";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !isPicked)
        {
            Debug.Log("Packed Picked!");
            package = other.gameObject;
            isPicked = true;
            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Customer" && isPicked)
        {
            Debug.Log("Mission Completed!");
            deliveredPackages++;
            deliveredPackagesText.text = "Delivered Packages : " + deliveredPackages.ToString();
            Destroy(package, destroyTime);
            isPicked = false;
            spriteRenderer.color = noPackageColor;
        }
    }

    private void Update()
    {
        if (isPicked)
        {
            package.transform.position = transform.position;
            package.transform.rotation = transform.rotation;
        }
    }
}
