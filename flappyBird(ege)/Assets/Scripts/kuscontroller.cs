using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class kuscontroller : MonoBehaviour
{
    public Rigidbody2D KusRigid;

    public float KusZiplamaHizi = 5f;
    public GameObject GameOverPanel, TiklamaParticle, PausePanel, AnaMenuPanel,
                        HowtoplayPanel, CreditsPanel;

    private scorecontroller scoreScript;
    private GameObject kus;
    
    void Start()
    {
        scoreScript = GameObject.Find("Toplayici").GetComponent<scorecontroller>();
        KusRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (AnaMenuPanel.activeInHierarchy|| GameOverPanel.activeInHierarchy || PausePanel.activeInHierarchy
            || HowtoplayPanel.activeInHierarchy || CreditsPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
        Vector3 MousePos = Input.mousePosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            KusRigid.velocity = new Vector2(0, 0);
            KusRigid.velocity = new Vector2(KusRigid.velocity.x,KusZiplamaHizi);

            MousePos.z = 2.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(MousePos);
            Instantiate(TiklamaParticle, objectPos, Quaternion.identity);

        }
        
        // if (PausePanel.activeInHierarchy)
        // {
        //     Time.timeScale = 0;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sinir")
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (other.gameObject.tag == "Star")
        {
            Destroy(other.gameObject);
            GameObject.Find("Toplayici").GetComponent<scorecontroller>().score += 5;
        }
    }

    public void RestartButonu()
    {
        
        // scoreScript.score = 0;
        // GameOverPanel.SetActive(false);
        Application.LoadLevel(0);
        // AnaMenuPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
    }

    public void StartButton()
    {
        scoreScript.score = 0;
        AnaMenuPanel.SetActive(false);
    }
}
