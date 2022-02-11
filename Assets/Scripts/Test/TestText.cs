using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestText : MonoBehaviour
{
    [SerializeField] private string _text = "Не забуть добавить надпись";
    [SerializeField] private int[] _sequencing;

    [SerializeField] private IShowText showText;
    [SerializeField] private IAction[] actions;

    private void Awake()
    {
        //print(showText);
        showText = gameObject.AddComponent<StandardShowText>();
        showText.Initialization(this);
    }
    private void Start()
    {
        showText.ShowText(_text);
    }

    private void Act()
    {
        //actions[_sequencing[0]].Act();
        print("act");
    }

    public void EndShowText()
    {
        
    }
}
