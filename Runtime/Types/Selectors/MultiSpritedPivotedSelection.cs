using System;
using System.Collections.Generic;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.WindRose.Authoring.Behaviours.Entities.Visuals.StateBundles;
using AlephVault.Unity.WindRose.Types;
using UnityEngine;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        namespace Selectors
        {
            /// <summary>
            ///   A multi-state & sprited selector involves just one sprite per state.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class MultiSpritedPivotedSelection : MappedSpriteGridSelection<
                Tuple<MultiSettings<Vector2Int>, Vector2>, MultiSettings<Sprite>
            >
            {
                public MultiSpritedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<MultiSettings<Vector2Int>, Vector2> selection
                ) : base(sourceGrid, selection)
                {
                    if (selection == null) throw new ArgumentNullException(nameof(selection));
                }

                /// <summary>
                ///   Validates and maps a dictionary of <see cref="Type"/> => <see cref="Vector2Int"/>. Each value
                ///   must be valid and each type must be a subclass of <see cref="SpriteBundle"/>.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The positions to select (mapped from type)</param>
                /// <returns>The sprites (mapped from type, and an idle state)</returns>
                protected override MultiSettings<Sprite> ValidateAndMap(
                    SpriteGrid sourceGrid, Tuple<MultiSettings<Vector2Int>, Vector2> selection
                )
                {
                    MultiSettings<Sprite> mapping = new MultiSettings<Sprite>();
                    foreach (KeyValuePair<State, Vector2Int> pair in selection.Item1)
                    {
                        mapping[pair.Key] = ValidateAndMapSprite(sourceGrid, pair.Value, selection.Item2);
                    }

                    return mapping;
                }
            }
        }
    }
}