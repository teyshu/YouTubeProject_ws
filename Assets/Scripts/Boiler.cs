using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] private int _stateMagic = 1; // уровень магии 3 макс
    [SerializeField] private Magic _playerMagic;

    public bool canCook = true;

    private int _ground = 0;
    private int _water = 0;
    private int _fire = 0;

    private List<Ingridient> _ingridients;

    private string _resultMagic = "";

    private void Awake()
    {
        _ingridients = new List<Ingridient>();
    }

    public void AddIngridient(Ingridient ing)
    {
        _ingridients.Add(ing);
        if(_ingridients.Count == 3)
        {
            canCook = false;
            CookMagic();
        }
    }

    private void CookMagic()
    {
        //определяем стихию магии
        foreach(Ingridient ing in _ingridients)
        {
            if(ing.element == "ground")
            {
                _ground++;
            }else if(ing.element == "water")
            {
                _water++;
            }else if(ing.element == "fire")
            {
                _fire++;
            }
        }

        if (_ground > _water && _ground > _fire)
        {
            _resultMagic = "ground";
        }else if(_water > _ground && _water > _fire)
        {
            _resultMagic = "water";
        }
        else if(_fire > _water && _fire > _ground)
        {
            _resultMagic = "fire";
        }

        _stateMagic++;

        GiveMagic();
    }
 
    public void GiveMagic()
    {
        switch(_resultMagic) 
        {
            case "ground":
                {
                    _playerMagic.ReceiveMagicGround(_stateMagic);
                }
                break;
            case "water":
                {
                    _playerMagic.ReceiveMagicWater(_stateMagic);
                }
                break;
            case "fire":
                {
                    _playerMagic.ReceiveMagicFire(_stateMagic);
                }
                break;
        }
    }
}
