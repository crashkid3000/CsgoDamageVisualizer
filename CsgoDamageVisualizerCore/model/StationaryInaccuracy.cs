namespace CsgoDamageVisualizerCore.model
{
    /// <summary>
    /// Defines the four choices of firing while not moving: <list type="bullet">
    /// <item>standing, primary firing mode</item>
    /// <item>crouching, primary fire mode</item>
    /// <item>standing, secondary fire mode</item>
    /// <item>crouching, secondary fire mode</item>
    /// </list>
    /// </summary>
        public enum StationaryInaccuracy
        {
            /// <summary>
            /// The user is standing and using the primary fire mode
            /// </summary>
            STANDING,
            /// <summary>
            /// The user is standing and using the secondary fire mode
            /// </summary>
            STANDING_ALT,
            /// <summary>
            /// The user is crouching and using the primary fire mode
            /// </summary>
            CROUCHING,
            /// <summary>
            /// THe user is crouching and using the secondary fire mode
            /// </summary>
            CROUCHING_ALT
        }
    
}
