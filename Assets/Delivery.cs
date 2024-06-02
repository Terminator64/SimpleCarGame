using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float PackageDestroyTimer =0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 NoPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log($"[{other.tag}] {other.tag.Length}");
            if (other.tag == "Package" && !hasPackage)
                {
                    Debug.Log("Package picked up");
                    hasPackage=true;
                    Destroy(other.gameObject, PackageDestroyTimer);
                    spriteRenderer.color=hasPackageColor;
                }

            if (other.tag == "Cel" && hasPackage)
                {
                    Debug.Log("Package delivered");
                    hasPackage=false;
                    spriteRenderer.color=NoPackageColor;
                }
        }            
}
