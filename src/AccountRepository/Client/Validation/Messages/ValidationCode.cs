// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

namespace Client.Validation.Messages
{
  public enum ValidationCode
  {
    None                = 0,

    // Unkown error
    Unknown             = 1,

    // Database error
    DbError             = 2,

    // Email
    EmailEmpty          = 3,
    EmailTooLong        = 4,
    EmailInvalidFormat  = 5,
    EmailInvalidChars   = 6,
    EmailInvalidDomain  = 7,

    // Phone
    PhoneEmpty          = 8,
    PhoneInvalidFormat  = 9,
    PhoneTimeout        = 10,

    // Name
    NameEmpty           = 11,
    NameInvalid         = 12,
    NameTimeout         = 13,

    // Success
    OK                  = 14
  }
}
