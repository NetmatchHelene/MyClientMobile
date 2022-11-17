namespace NetMatch.MyClientMobile.Business.Logging
{
    public class SerilogCustomizationOptions
    {       /// <summary>
            /// Gets the name of the group to which the application belongs.
            /// </summary>
        public string ApplicationGroup { get; set; }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// The Google StackDriver specific settings
        /// </summary>
        public StackDriverLoggingOptions StackDriver { get; set; }

        /// <summary>
        /// The Console specific settings
        /// </summary>
        public ConsoleLoggingOptions Console { get; set; }
    }
}
