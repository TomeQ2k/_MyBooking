namespace MyBooking.Core.Helpers
{
    public static class ValidatorMessages
    {
        public const string RequiredValidatorMessage = "Field is required";

        public const string WhitespacesValidatorMessage = "Whitespaces are not allowed";

        public static string StringLengthValidatorMessage(int minLength, int maxLength)
            => minLength != 0
            ? $"Field must have between {minLength} and {maxLength} characters"
            : $"Field cannot have more than {maxLength} characters";
    }
}