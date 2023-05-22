namespace error_handling_demo.Domain
{
    public class Error : ValueObject
    {
        public string Code { get; set; }
        public string? DebugInfo { get; set; }

        private Error(string code, string? debugInfo = default)
        {
            Code = code;
            DebugInfo = debugInfo;
        }

        public static Error ArgumentNull(string? debugInfo = default)
        {
            return new Error("Error.ArgumentNull", debugInfo);
        }

        public static Error InvalidOperation(string? debugInfo = default)
        {
            return new Error("Error.InvalidOperation", debugInfo);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
