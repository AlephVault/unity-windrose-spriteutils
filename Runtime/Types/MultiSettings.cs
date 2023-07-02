using System;
using System.Collections.Generic;
using AlephVault.Unity.WindRose.Types;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        /// <summary>
        ///   A multi setting is a dictionary over string states and their contents.
        /// </summary>
        /// <typeparam name="T">The type to map</typeparam>
        public class MultiSettings<T> : Dictionary<State, T> {}
    }
}