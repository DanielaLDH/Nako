using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaPause : MonoBehaviour
{
    public GameObject Pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onPause();
    }

    public void onPause()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void returnGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }
}
