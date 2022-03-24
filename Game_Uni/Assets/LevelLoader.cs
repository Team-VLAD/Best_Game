using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public static bool IsDoubleTap(){ //removable
         bool result = false;
         float MaxTimeWait = 1;
         float VariancePosition = 1;
 
         if( Input.touchCount == 3  && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             float DeltaTime = Input.GetTouch (0).deltaTime;
             float DeltaPositionLenght=Input.GetTouch (0).deltaPosition.magnitude;
 
             if ( DeltaTime> 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                 result = true;                
         }
         return result;
     }

    // Update is called once per frame
    void Update()
    {
        if(IsDoubleTap()==true)//(Input.GetKeyDown("space"))//if(Input.GetMouseButtonDown(1))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait for it to end
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
