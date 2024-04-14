using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ISelectable
{
    public Color defaultColor, selectedColor;
    [SerializeField] private int _indexX, _indexY;
    private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer topLayer;
    private bool _selected;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void SetCoordination(int x, int y)
    {
        _indexX = x;
        _indexY = y;
    }

    public void SetColor(Color color)
    {
        defaultColor = color;
        (renderer).color = defaultColor;
    }

    public void OnHover()
    {
        topLayer.enabled = true;
    }

    public void OnOffHover()
    {
        topLayer.enabled = false;
    }

    public void OnSelect()
    {
        if (GridManager.selectingTile == this)
        {
            renderer.color = defaultColor;
            GridManager.selectingTile = null;
        }
        else
        {
            renderer.color = selectedColor;
            GridManager.selectingTile = GridManager.GetTileSelected(new Vector2(_indexX, _indexY));
            
        }
        
       
    }

    public void OffSelect()
    {
        renderer.color = defaultColor;
    }

    
}
