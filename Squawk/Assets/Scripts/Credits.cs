using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script for bringing player back to title screen after credits are done
public class Credits : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); //Load the first Scene (Title Screen) in Build Settings
    }
}
