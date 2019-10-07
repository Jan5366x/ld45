using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortingOrderChildScript : MonoBehaviour
{
    private const double ErrorTimeout = 5D;
    private const double ScriptCheckTimeout = 2D;
    public int childLayerOffset = 0;
    private SortingOrderScript _parentScript;
    private SpriteRenderer _spriteRenderer;
    private bool _hasOwnRenderer = false;
    private bool _parentScriptFound = false;

    private double _errorTimer = ErrorTimeout;
    private double _scriptCheckTimer = 0D;
    private Transform _lastParent = null;
    void Awake()
    {
        PrepareSpriteRenderer();
    }
    
    void Update()
    {
        // update sprite renderer and parent script if in Editor mode to provide live updates
        if(!Application.isPlaying)
            PrepareSpriteRenderer();
        
        
      
        if (_scriptCheckTimer > 0)
        {
            _errorTimer -= Time.deltaTime;
        }
        else
        {
            // check if script must be searched again
            if (_lastParent != transform.parent)
            {
                _parentScriptFound = false;
                FindParentScript();
                _lastParent = transform.parent;
            }

            _scriptCheckTimer = ScriptCheckTimeout;
        }
        
        
        // final update hook
        if (_hasOwnRenderer && _parentScriptFound)
        {
            _spriteRenderer.sortingOrder = _parentScript.GetSortingOrder() + childLayerOffset;
        }
        else 
        {
            if (_errorTimer > 0)
            {
                _errorTimer -= Time.deltaTime;
            }
            else
            {
                Debug.LogError("Missing parent sorting order script or sprite renderer!");
                _errorTimer = ErrorTimeout;
            }
        }
    }

    private void PrepareSpriteRenderer()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hasOwnRenderer = _spriteRenderer != null;

       
    }


    private void FindParentScript()
    {
        Transform current = transform.parent;
        while (!_parentScriptFound && current != null)
        {
            SortingOrderScript script = current.GetComponent<SortingOrderScript>();

            if (script != null)
            {
                _parentScript = script;
                _parentScriptFound = true;
                break;
            }

            current = current.parent;
        }
    }
}
