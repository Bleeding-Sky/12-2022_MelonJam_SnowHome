using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneHandler : MonoBehaviour
{
   public float scene1Timer;
    float elapsedTime = 0;
    public Scene intro;
    public Scene game;
    public Scene ending;

    // Start is called before the first frame update
    void Start()
    {
        intro = SceneManager.GetSceneByName("IntroCutscene");
        game = SceneManager.GetSceneByName("SampleScene");
        ending = SceneManager.GetSceneByName("EndingCutscene");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene() == intro)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > scene1Timer)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (SceneManager.GetActiveScene() == game)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.GetComponent<ClothingHandler>().hasHat &&
                player.GetComponent<ClothingHandler>().hasScarf &&
                player.GetComponent<ClothingHandler>().hasPipe)
            {
                SceneManager.LoadScene("EndingCutscene");
                Debug.Log("Loading ending cutscene");
            }
        }
    }
}
