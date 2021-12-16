
using UnityEngine;

namespace Platformer.Quests
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }

}
