using FluentValidation.Validators;

namespace LaborVolumeCalculator.Localization
{
    public class FluentValidationLanguageManager : FluentValidation.Resources.LanguageManager
    {
        public FluentValidationLanguageManager()
        {          
			#pragma warning disable CS0618
            AddTranslation("ru", nameof(EmailValidator), "Не валидный email.");
			#pragma warning restore CS0618
			AddTranslation("ru", nameof(GreaterThanOrEqualValidator), "Значение должно быть больше или равно {ComparisonValue}.");
			AddTranslation("ru", nameof(GreaterThanValidator), "Значение должно быть больше {ComparisonValue}.");
			AddTranslation("ru", nameof(LengthValidator), "Длина строки должна быть между {MinLength} и {MaxLength} символов. Вы ввели {TotalLength} символов.");
			AddTranslation("ru", nameof(MinimumLengthValidator), "Длина строки должна быть минимум {MinLength} символов. Вы ввели {TotalLength} символов.");
			AddTranslation("ru", nameof(MaximumLengthValidator), "Длина строки должна быть максимум {MaxLength} символов. Вы ввели {TotalLength} символов.");
			AddTranslation("ru", nameof(LessThanOrEqualValidator), "Значение должно быть меньше или равно {ComparisonValue}.");
			AddTranslation("ru", nameof(LessThanValidator), "Значение должно быть меньше {ComparisonValue}.");
			AddTranslation("ru", nameof(NotEmptyValidator), "Поле должно быть заполнено.");
			AddTranslation("ru", nameof(NotEqualValidator), "Значение должно отличаться от {ComparisonValue}.");
			AddTranslation("ru", nameof(NotNullValidator), "Поле должно быть заполнено.");
			AddTranslation("ru", nameof(PredicateValidator), "Указанное условие не было выполнено для поля.");
			AddTranslation("ru", nameof(AsyncPredicateValidator), "Указанное условие не было выполнено для поля.");
			AddTranslation("ru", nameof(RegularExpressionValidator), "Значение имеет не верный формат.");
			AddTranslation("ru", nameof(EqualValidator), "Значение должно быть равно {ComparisonValue}.");
			AddTranslation("ru", nameof(ExactLengthValidator), "Значение должно иметь длинну {MaxLength} символов. Вы ввели {TotalLength} символов.");
			AddTranslation("ru", nameof(InclusiveBetweenValidator), "Значение должно быть между {From} и {To}. Вы ввели {Value}.");
			AddTranslation("ru", nameof(ExclusiveBetweenValidator), "Значение должно быть между {From} и {To} (не включительно). Вы ввели {Value}.");
			AddTranslation("ru", nameof(CreditCardValidator), "Не верный номер кредитной карты.");
			AddTranslation("ru", nameof(ScalePrecisionValidator), "Значение должно быть не более {ExpectedPrecision} цифр, с разрешением на {ExpectedScale} десятичных знаков. Обнаружено {Digits} цифр и {ActualScale} десятичных знаков.");
			AddTranslation("ru", nameof(EmptyValidator), "Поле должно быть пустым.");
			AddTranslation("ru", nameof(NullValidator), "Поле должно быть пустым.");
			AddTranslation("ru", nameof(EnumValidator), "Поле содержит диапазон значенией, который не включает {PropertyValue}.");
			
			AddTranslation("ru", "Length_Simple", "Значение должно быть от {MinLength} да {MaxLength} символов.");
			AddTranslation("ru", "MinimumLength_Simple", "Значение должно иметь длину не менее {MinLength} символов.");
			AddTranslation("ru", "MaximumLength_Simple", "Значение должно иметь длину не более {MaxLength} символов.");
			AddTranslation("ru", "ExactLength_Simple", "Значение должно иметь длинну {MaxLength} символов.");
			AddTranslation("ru", "InclusiveBetween_Simple", "Значение должно быть от {From} до {To} (включительно).");
        }
    }
}