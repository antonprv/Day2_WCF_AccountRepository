// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using Client.Validation.Messages;

namespace Client.Validation
{
  public readonly struct ValidationResult
  {
    public bool IsValid { get; }
    public ValidationCode Code { get; }

    private ValidationResult(bool isValid, ValidationCode code)
    {
      IsValid = isValid;
      Code = code;
    }

    public static ValidationResult Ok() =>
        new ValidationResult(true, ValidationCode.OK);

    public static ValidationResult Fail(ValidationCode code) =>
        new ValidationResult(false, code);
  }
}
