using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceNameController : MonoBehaviour
{

    /// <summary>
    /// Bool to show if you need to show the place name.
    /// </summary>
    [SerializeField] bool needToChangeText;


    /// <summary>
    /// place name label used to show the locations name.
    /// </summary>
    [SerializeField] string placeName;


    /// <summary>
    /// Gameobject of the text, use to change the name.
    /// </summary>
    [SerializeField] GameObject text;

    /// <summary>
    /// you text to display in the UI.
    /// </summary>
    [SerializeField] Text placeText;



    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (needToChangeText)
            {
                StartCoroutine(PlaceNameCoroutine());
            }
        }
    }

    private IEnumerator PlaceNameCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);

        text.SetActive(false);
    }
}
