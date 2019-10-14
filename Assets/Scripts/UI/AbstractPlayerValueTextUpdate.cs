using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class AbstractPlayerValueTextUpdate : MonoBehaviour
    {
        private const double UpdateDelay = 0.5D;
        private double _updateTimer = 0D;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            if (_text == null)
            {
                Debug.Log("Can't find text component for player value text update!");
                Destroy(this);
            }
        }

        void Update()
        {
            if (_updateTimer <= 0D)
            {
                ApplyText(FetchValue());
                _updateTimer = UpdateDelay;
            }
            else
            {
                _updateTimer -= Time.deltaTime;
            }
        }

        protected abstract string FetchValue();

        private void ApplyText(String value)
        {
            _text.text = value;
        }
    }
}