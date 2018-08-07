namespace StartWithHat
{
    /// <summary>
    /// This class contains the options available for this mod.
    /// </summary>
    public class ModOptions
    {
        #region Constants

        public static readonly int DefaultHat = 24;

        #endregion

        #region Constructors

        public ModOptions()
        {
            this.Hat = ModOptions.DefaultHat;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The default hat to start with.
        /// </summary>
        public int Hat
        {
            get; set;
        }

        #endregion
    }
}