using System;
using System.Reflection;
using System.Text;
using KSoftNet.Enums;
using Refit;

namespace KSoftNet.Utils {
  internal class ParameterFormatter : IUrlParameterFormatter {

    public string Format(object value, ICustomAttributeProvider attributeProvider, Type type) {
      if (value == null)
        return null;

      var parameterType = Denullify(type);

      if (parameterType == typeof(Span)) {
        return GetLowerEnumName<Span>(value);
      }

      if (parameterType == typeof(ReportType)) {
        return GetLowerEnumName<ReportType>(value);
      }

      if (parameterType == typeof(IconPack)) {
        return GetLowerEnumName<IconPack>(value);
      }

      if (parameterType == typeof(Unit)) {
        return GetLowerEnumName<Unit>(value);
      }

      if (parameterType == typeof(CurrencyCode)) {
        return GetUpperEnumName<CurrencyCode>(value);
      }

      // ReSharper disable once ConvertIfStatementToReturnStatement
      if (parameterType == typeof(Language)) {
        return Enum.GetName(typeof(Language), value)?.PascalToKebabCase();
      }

      return value.ToString().ToLowerInvariant();
    }

    private static Type Denullify(Type type) {
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        return type.GetGenericArguments()[0];

      return type;
    }

    private static string GetLowerEnumName<T>(object e) {
      return Enum.GetName(typeof(T), e)?.ToLowerInvariant();
    }

    private static string GetUpperEnumName<T>(object e) {
      return Enum.GetName(typeof(T), e)?.ToUpperInvariant();
    }

  }

  internal static class StringExtensions {
    internal static string PascalToKebabCase(this string source) {
      if (source is null) return null;

      if (source.Length == 0) return string.Empty;

      var builder = new StringBuilder();

      for (var i = 0; i < source.Length; i++) {
        // if current char is already lowercase
        if (char.IsLower(source[i])) {
          builder.Append(source[i]);
        }
        // if current char is the first char
        else if (i == 0) {
          builder.Append(char.ToLower(source[i]));
        }
        // if current or previous char is -
        else if (source[i - 1] == '-' || source[i] == '-') {
          builder.Append(char.ToLower(source[i]));
        }
        // if current char is a number and the previous is not
        else if (char.IsDigit(source[i]) && !char.IsDigit(source[i - 1])) {
          builder.Append('-');
          builder.Append(source[i]);
        }
        // if current char is a number and previous is
        else if (char.IsDigit(source[i])) {
          builder.Append(source[i]);
        }
        // if current char is upper and previous char is lower
        else if (char.IsLower(source[i - 1])) {
          builder.Append('-');
          builder.Append(char.ToLower(source[i]));
        }
        // if current char is upper and next char doesn't exist or is upper
        else if (i + 1 == source.Length || char.IsUpper(source[i + 1])) {
          builder.Append(char.ToLower(source[i]));
        }
        // if current char is upper and next char is lower
        else {
          builder.Append('-');
          builder.Append(char.ToLower(source[i]));
        }
      }

      return builder.ToString();
    }
  }
}