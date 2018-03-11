using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class goalPickup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayLoad());

        }
    }

    IEnumerator DelayLoad()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
