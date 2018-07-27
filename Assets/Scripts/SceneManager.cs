using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    GameController gamecontroller;
    public GameObject infoku;


    // Use this for initialization
    void Start () {
	
	}

   
	// Update is called once per frame
	void Update () {
	
	}
    public void timermode()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        gamecontroller.itungin = true;
    }

    public void regularmode()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneBaru");
    }

    public void mixmode()
    {
       
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene23");

    }

    public void tonextmenu()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu Scene");

    }

    public void showcredit()
    {
        Instantiate(infoku, Vector3.zero, Quaternion.identity);
        Debug.Log("tampil");
    }


     IEnumerator credit()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
