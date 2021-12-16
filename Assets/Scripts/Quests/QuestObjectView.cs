
using UnityEngine;

namespace Platformer.Quests
{
    public class QuestObjectView : LevelObjectView
    {
        public int Id => _id;

        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }

    }

}
