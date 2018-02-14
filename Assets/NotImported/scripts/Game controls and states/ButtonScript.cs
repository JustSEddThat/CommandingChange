using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour 
{
   
    void Start()
    {
      
    }

    public void toThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void unPause()
    {
        gameObject.SetActive(false);
    }
    public void toCredits()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMainLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void toTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void toLastLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex - 1 != 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
