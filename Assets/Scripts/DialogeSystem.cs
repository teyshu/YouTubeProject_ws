using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogeSystem : MonoBehaviour
{
    [SerializeField] private string[] _lines;
    [SerializeField] private float _textSpeed;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _panel;

    [SerializeField] private int index;

    [SerializeField] private Timer _timer;

    bool canSkeep = true;
    private EnemyController _enemy;
    private BroomController _broom;


    private void Start()
    {
        _enemy = FindObjectOfType<EnemyController>();
        _enemy.gameObject.SetActive(false);

        _broom = FindObjectOfType<BroomController>();
        _broom.gameObject.SetActive(false);

        _panel.SetActive(true);
        _text.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in _lines[index].ToCharArray())
        {
            _text.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
        _panel.SetActive(true);
    }

    private void NextLines()
    {
        if(index < _lines.Length - 1)
        {
            index++;
            _text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _enemy.gameObject.SetActive(true);
            _broom.gameObject.SetActive(true);
            _panel.SetActive(false);
            _text.gameObject.SetActive(false);
            canSkeep = false;
            _timer.StartTimer();
        }
    }

    public void SkipText()
    {
        if(_text.text == _lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            _text.text = _lines[index].ToString();
        }
    }

    private void Update()
    {
        if(canSkeep && Input.GetKeyDown(KeyCode.Mouse0))
        {
            SkipText();
        }
    }

}
