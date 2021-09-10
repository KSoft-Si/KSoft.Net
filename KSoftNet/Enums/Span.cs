using System.ComponentModel;

namespace KSoftNet.Enums {
  /// <summary>
  /// Reddit search span
  /// </summary>
  public enum Span {
    /// <summary>
    /// Posts within hour
    /// </summary>
    Hour,

    /// <summary>
    /// Posts within day
    /// </summary>
    Day,

    /// <summary>
    /// Posts within week
    /// </summary>
    Week,

    /// <summary>
    /// Posts within month
    /// </summary>
    Month,

    /// <summary>
    /// Posts within year
    /// </summary>
    Year,

    /// <summary>
    /// Posts from all time
    /// </summary>
    All
  }
}