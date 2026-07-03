using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xasu.HighLevel;
using TinCan;

namespace Assets.Scripts.Tracker
{
    public class CustomHighLevelTracker : AbstractHighLevelTracker<CustomHighLevelTracker>
    {
        public enum Verb { Interacted, Choosed }
        public enum TrackedGameObject { Enemy, Npc, Item, GameObject }

        private readonly Dictionary<Enum, string> verbIds = new Dictionary<Enum, string>
        {
            { Verb.Interacted,  "http://adlnet.gov/expapi/verbs/interacted"      },
            { Verb.Choosed,  "http://adlnet.gov/expapi/verbs/choosed"      },
        };

        private readonly Dictionary<Enum, string> typeIds = new Dictionary<Enum, string>
        {
            { TrackedGameObject.GameObject, "https://w3id.org/xapi/seriousgames/activity-types/game-object"},
            { TrackedGameObject.Item, "https://w3id.org/xapi/seriousgames/activity-types/item"}

        };

        protected override Dictionary<Enum, string> VerbIds => verbIds;
        protected override Dictionary<Enum, string> TypeIds => typeIds;
        protected override Dictionary<Enum, string> ExtensionIds => null; 

        /// <summary>
        /// Player interacted with a game object, including name and description.
        /// </summary>
        public StatementPromise InteractedWithDescription(
            string gameobjectId,
            TrackedGameObject type,
            string name,
            string description)
        {
            return Enqueue(new Statement
            {
                verb = GetVerb(Verb.Interacted),

                target = GetTargetActivity(gameobjectId, type, name, description)
            });
        }

        public StatementPromise ChoosedWithDescription(
            string gameobjectId,
            TrackedGameObject type,
            string name,
            string description)
        {
            return Enqueue(new Statement
            {
                verb = GetVerb(Verb.Choosed),

                target = GetTargetActivity(gameobjectId, type, name, description)
            });
        }
    }
}
