﻿using Light.Framework.Core.Core;

namespace Light.Framework.Core.Data
{
    public interface IValidateEntity
    {
        void Validate();
    }

    public static class ValidateEntityExtensions
    {
        public static void NotNull<T>(this T entity, string value, string message) where T : IValidateEntity
        {
            entity.Valid(!string.IsNullOrWhiteSpace(value), message);
        }

        public static void Valid<T>(this T entity, bool valid, string message) where T : IValidateEntity
        {
            if (!valid)
            {
                throw new KnownException(message);
            }
        }
    }
}
