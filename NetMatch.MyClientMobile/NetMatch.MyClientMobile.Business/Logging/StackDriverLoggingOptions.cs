namespace NetMatch.MyClientMobile.Business.Logging
{
    public class StackDriverLoggingOptions
    {
        /// <summary>
        /// Gets a boolean if the StackDriver sink should be enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Google StackDriver project Id.
        /// </summary>
        public string ProjectId { get; set; }
    }
}
