using System;

namespace Platformer.Quests
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }

}
