using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Image[] starImages; // Array to hold star images

    private void Start()
    {
        int stars = PlayerPrefs.GetInt("Stars", 0); // Get the number of stars

        // Update star images based on the number of stars
        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < stars)
            {
                starImages[i].enabled = true; // Show star
            }
            else
            {
                starImages[i].enabled = false; // Hide star
            }
        }
    }
}
