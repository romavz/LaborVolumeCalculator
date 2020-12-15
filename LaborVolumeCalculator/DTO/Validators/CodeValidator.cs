using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public static class CodeValidator
    {
        public static IRuleBuilderOptions<T, string> IsGroupOfDidgitsSeparatedByDot<T> (this IRuleBuilder<T, string> ruleBuilder)
        {
            string zero_or_more_dot_separated_groups_of_didgits = @"^(?:\d+\.)*";
            string one_or_more_didgits = @"\d+$";
            string codePattern = $"{zero_or_more_dot_separated_groups_of_didgits}{one_or_more_didgits}";

            // example 123.12323.33423 or 12345
            return ruleBuilder.Matches(codePattern).WithMessage("'{PropertyName}' должен состоять из групп цифр, разделенных точкой");
        }
    }
}