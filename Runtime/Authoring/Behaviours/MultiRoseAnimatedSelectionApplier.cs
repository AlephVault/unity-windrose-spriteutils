using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AlephVault.Unity.SpriteUtils.Authoring.Types;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.WindRose.Authoring.Behaviours.Entities.Visuals;
using AlephVault.Unity.WindRose.Authoring.ScriptableObjects.VisualResources;
using AlephVault.Unity.WindRose.SpriteUtils.Types;
using AlephVault.Unity.WindRose.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Authoring
    {
        namespace Behaviours
        {
            /// <summary>
            ///   Multi-State Rose-Animated selector appliers are added on top of <see cref="MultiRoseAnimated"/>
            ///   visuals so they are able to replace the multiple animation roses they use.
            /// </summary>
            [RequireComponent(typeof(MultiRoseAnimated))]
            public class MultiRoseAnimatedSelectionApplier : MultiStateSelectionApplier<AnimationRose, MultiRoseAnimated> {}
        }
    }
}