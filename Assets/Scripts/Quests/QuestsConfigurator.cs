using UnityEngine;

namespace Platformer.Quests
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestObjectView _singleQuestView;
        private Quest _singleQuest;

        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel());
            _singleQuest.Reset();
        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
        }

    }
}
