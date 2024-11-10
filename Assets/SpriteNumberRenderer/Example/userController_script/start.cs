using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject loginCanvas;
    public GameObject playerInfoCanvas;
    public GameObject chooseSceneCanvas;
    public GameObject langageCanvas;

    public void showLoginCanvas(){
        loginCanvas.SetActive(true);
    }
    // public void login(){
    //     Debug.Log("login");
    //     loginCanvas.SetActive(false);
    //     startCanvas.SetActive(false);
    //     playerInfoCanvas.SetActive(true);

    // }

    public void returnStart(){
        loginCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }

    public void logout(){
        Debug.Log("logout");
        loginCanvas.SetActive(false);
        startCanvas.SetActive(true);
        playerInfoCanvas.SetActive(false);
    }

    public void enterGame(){
        playerInfoCanvas.SetActive(false);
        chooseSceneCanvas.SetActive(true);
    }

    public void returnlogin()
    {
        loginCanvas.SetActive(true);
        chooseSceneCanvas.SetActive(false);
    }

    public void returnselect()
    {
        playerInfoCanvas.SetActive(true);
        chooseSceneCanvas.SetActive(false);
    }
    public void showlangageCanvas(){
        langageCanvas.SetActive(true);
    }
    public void exitlangageCanvas(){
        langageCanvas.SetActive(false);
    }
}
