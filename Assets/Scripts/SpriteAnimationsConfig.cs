using System;
using System.Collections.Generic;
using UnityEngine;

public enum Track
{
    idle,
    run,
    jumpUp,
    jumpDown,
    blink,
    coinDance
}

[CreateAssetMenu(fileName = "SpriteAnimationsCnfg", menuName = "Configs/SpriteAnimationsCnfg", order = 1)]
public class SpriteAnimationsConfig : ScriptableObject
{
    [Serializable]
    public class SpritesSequence
    {
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
    public List<SpritesSequence> Sequences = new List<SpritesSequence>();
}
