using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : IDisposable
{
    private const float _animationsSpeed = 10;

    private LevelObjectView _characterView;
    private SpriteAnimator _spriteAnimator;
    private List<LevelObjectView> _coinViews;

    public CoinsManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimator spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
        _coinViews = coinViews;
        _characterView.OnLevelObjectContact += OnLevelObjectContact;

        foreach (var coinView in coinViews)
        {
            _spriteAnimator.StartAnimation(coinView.SpriteRenderer, Track.coinDance, true, _animationsSpeed);
        }
    }

    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
            _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
            GameObject.Destroy(contactView.gameObject);
        }
    }

    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }
}

