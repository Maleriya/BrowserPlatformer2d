using UnityEngine;

namespace Platformer.Quests
{
    public sealed class SwitchQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }

    }
}
