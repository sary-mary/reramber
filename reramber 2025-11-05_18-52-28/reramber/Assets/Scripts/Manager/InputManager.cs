using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    [SerializeField] private LandInputsubscription getInput;


    private void OnEnable()
    {
        Instance = this;
    }


}
