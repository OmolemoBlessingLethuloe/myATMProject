using MyATMProject.Debugging;

namespace MyATMProject
{
    public class MyATMProjectConsts
    {
        public const string LocalizationSourceName = "MyATMProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fb1ffeb6fb8948a0b9e13f5e40dd61c8";
    }
}
