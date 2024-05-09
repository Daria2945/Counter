using System.Collections;
using TMPro;
using UnityEngine;

public class NumberView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNumber;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private int _currentNumber;
    private bool _isNumberDisplay;

    private void Start()
    {
        _currentNumber = 0;
        _textNumber.text = _currentNumber.ToString("");

        _isNumberDisplay = true;

        ResetCoroutine();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_isNumberDisplay == false)
            {
                _isNumberDisplay = true;
                ResetCoroutine();
            }
            else
            {
                _isNumberDisplay = false;
                Stop();
            }
        }
    }

    private void Stop()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void ResetCoroutine()
    {
        _coroutine = StartCoroutine(SmoothIncreaseNumber());
    }

    private IEnumerator SmoothIncreaseNumber()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (_isNumberDisplay)
        {
            _currentNumber++;
            _textNumber.text = _currentNumber.ToString("");

            yield return wait;
        }
    }
}