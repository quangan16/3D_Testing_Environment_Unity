using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager2 : MonoBehaviour
{
    
    [SerializeField] private ISelectable _lastHover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetObjectPointed();
    }

    public void GetObjectPointed()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ISelectable selectable = hit.collider.GetComponent<ISelectable>();
            if (selectable != null)
            {
                if (_lastHover != null && _lastHover != selectable)
                {
                    _lastHover.OnOffHover();
                }
                selectable.OnHover();
                _lastHover = selectable;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (GridManager.selectingTile != null)
                {
                    GridManager.selectingTile.OffSelect();
                }
                selectable.OnSelect();
            }
            
           
                
                
        }
        else if (_lastHover != null)
        {
            _lastHover.OnOffHover();
            
        }
        
    }

    public void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray);
    }
}
