using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageSelect : MonoBehaviour
{
    [SerializeField]
    public GameObject resetOk;

    public void ClickReset()
    {
        resetOk.SetActive(true);
    }
    public void ClickStage1()
    {

        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);

    }

    public void ClickStage2()
    {
        SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
    }

    public void ClickBack()
    {
        resetOk.SetActive(false);
    }

    //public void ClickStage2()
    //{
    //    SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
    //}    
    //public void ClickStage3()
    //{
    //    SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
    //}    
    //public void ClickStage4()
    //{
    //    SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
    //}    
    //public void ClickStage5()
    //{
    //    SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
    //}    
    //public void ClickStage6()
    //{
    //    SceneManager.LoadScene("Stage6", LoadSceneMode.Single);
    //}    
    //public void ClickStage7()
    //{
    //    SceneManager.LoadScene("Stage7", LoadSceneMode.Single);
    //}    
    //public void ClickStage8()
    //{
    //    SceneManager.LoadScene("Stage8", LoadSceneMode.Single);
    //}    
    //public void ClickStage9()
    //{
    //    SceneManager.LoadScene("Stage9", LoadSceneMode.Single);
    //}

}
