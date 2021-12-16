using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Quests
{
    [CreateAssetMenu(menuName = "QuestStoryConfig", fileName = "QuestStoryConfig", order = 0)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }

}
