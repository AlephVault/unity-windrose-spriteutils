using System;
using System.Collections.Generic;
using AlephVault.Unity.SpriteUtils.Authoring.Types;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.WindRose.Authoring.Behaviours.Entities.Visuals;
using AlephVault.Unity.WindRose.Authoring.ScriptableObjects.VisualResources;
using AlephVault.Unity.WindRose.SpriteUtils.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Authoring
    {
        namespace Behaviours
        {
            /// <summary>
            ///   Multi-State Rose-Sprited selector appliers are added on top of <see cref="MultiRoseSprited"/>
            ///   visuals so they are able to replace the multiple sprite roses they use.
            /// </summary>
            [RequireComponent(typeof(MultiRoseSprited))]
            public class MultiRoseSpritedSelectionApplier : MultiStateSelectionApplier<SpriteRose, MultiRoseSprited> {}
        }
    }
}