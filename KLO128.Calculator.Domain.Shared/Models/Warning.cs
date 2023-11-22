namespace KLO128.Calculator.Domain.Shared.Models
{
    public class Warning : Exception
    {
        public string Code { get; set; }

        public string[] Args { get; set; }

        public static Warning CreateForTesting(string code)
        {
            return new Warning { Code = code };
        }

        private Warning()
        {
            Code = string.Empty;
            Args = new string[0];
        }

        public Warning(string code, params string[] args) : base(string.Format(Translations.ResourceManager.GetString(code) ?? new System.Resources.ResourceManager(Translations.ResourceManager.GetType())?.GetString(code)!, args))
        {
            Code = code;
            Args = args;
        }
    }
}
