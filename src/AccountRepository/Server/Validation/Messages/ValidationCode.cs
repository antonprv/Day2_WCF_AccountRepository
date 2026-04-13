// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

namespace Server.Validation.Messages
{
  public enum ValidationCode
  {
    None,

    // Unkown error
    Unknown,

    // Database error
    DbError,

    // Email
    EmailEmpty,
    EmailTooLong,
    EmailInvalidFormat,
    EmailInvalidChars,
    EmailInvalidDomain,

    // Phone
    PhoneEmpty,
    PhoneInvalidFormat,
    PhoneTimeout,

    // Name
    NameEmpty,
    NameInvalid,
    NameTimeout,

    // Success
    OK
  }
}
