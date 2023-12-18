using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSequence : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;

    void Start()
    {
        StartCoroutine(ShowImagesSequentially());
    }

    IEnumerator ShowImagesSequentially()
    {
        yield return new WaitForSeconds(0.1f);

        // Show Image 1
        image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.13f);

        // Hide Image 1, Show Image 2
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.13f);

        // Hide Image 2, Show Image 3
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.13f);

        // Hide Image 3
        image3.gameObject.SetActive(false);
    }
}
