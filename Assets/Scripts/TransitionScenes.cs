using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( SceneTransition());
    }

   IEnumerator SceneTransition()
   {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);   
   }
    // Update is called once per frame
   
}
